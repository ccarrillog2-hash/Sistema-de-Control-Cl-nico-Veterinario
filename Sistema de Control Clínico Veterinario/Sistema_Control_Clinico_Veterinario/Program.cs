using System;
using System.Collections.Generic;
using System.Linq;
using SistemaVeterinario.logica;

namespace Sistema_Control_Clinico_Veterinario
{
    class Program
    {
        static List<Cliente> clientes = new List<Cliente>();
        static List<Mascota> mascotas = new List<Mascota>();
        static List<Cita> citas = new List<Cita>();
        static List<Veterinario> veterinarios = new List<Veterinario>();
        static List<Recepcionista> recepcionistas = new List<Recepcionista>();
        static List<Factura> facturas = new List<Factura>();

        static int contadorClientes = 1;
        static int contadorMascotas = 1;
        static int contadorCitas = 1;
        static int contadorConsultas = 1;
        static int contadorFacturas = 1;
        static int contadorPagos = 1;

        static Persona colaboradorActual;
        static string rolActual = "";
        static Cliente clienteActual;
        static Mascota mascotaActual;

        static void Main(string[] args)
        {
            Console.Title = "Sistema de Control Clinico Veterinario";

            CargarUsuariosDePrueba();

            while (true)
            {
                // 🔹 LOGIN
                if (!IniciarSesion())
                {
                    Console.WriteLine("\n   Saliendo del sistema...");
                    Console.ReadLine();
                    return;
                }

                // 🔹 MENÚ
                int resultado = MostrarMenu();

                if (resultado == 11)
                {
                    Console.Clear();
                    Console.WriteLine("\n   Cerrando sesion...");
                    Console.WriteLine("   Presione ENTER para volver al login...");
                    Console.ReadLine();
                    continue;
                }

                if (resultado == 12)
                {
                    break;
                }
            }

            Console.WriteLine("\n   Gracias por usar el sistema. Presione ENTER para cerrar.");
            Console.ReadLine();
        }

        static void CargarUsuariosDePrueba()
        {
            recepcionistas.Add(new Recepcionista
            {
                Id = 1,
                Nombre = "Cindy Carillo",
                Dpi = "1234567890101",
                Usuario = "cindy",
                Contrasena = "1234",
                CodigoEmpleado = "R001",
                Turno = "Matutino"
            });

            veterinarios.Add(new Veterinario
            {
                Id = 1,
                Nombre = "Dr. Cesar Canel",
                Dpi = "9876543210101",
                Usuario = "cesar",
                Contrasena = "1234",
                CodigoVet = "V001",
                Especialidad = "General",
                Horario = "8:00-17:00",
                Consultorio = "C1"
            });
        }
        static bool IniciarSesion()
        {
            int intentos = 0;

            while (intentos < 3)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("========================================================");
                Console.WriteLine("   SISTEMA DE CONTROL CLINICO VETERINARIO");
                Console.WriteLine("========================================================");
                Console.ResetColor();
                Console.WriteLine("\n   INGRESE SUS DATOS DE COLABORADOR\n");

                Console.Write("   Usuario: ");
                string user = (Console.ReadLine() ?? "").Trim();

                Console.Write("   Contrasena: ");
                string pass = LeerContrasena();

                // Buscar recepcionista
                var recep = recepcionistas.FirstOrDefault(r =>
                    r.Usuario != null &&
                    r.Usuario.Equals(user, StringComparison.OrdinalIgnoreCase) &&
                    r.Contrasena == pass);

                if (recep != null)
                {
                    colaboradorActual = recep;
                    rolActual = "Recepcionista";
                    MostrarBienvenida();
                    return true;
                }

                // Buscar veterinario
                var vet = veterinarios.FirstOrDefault(v =>
                    v.Usuario != null &&
                    v.Usuario.Equals(user, StringComparison.OrdinalIgnoreCase) &&
                    v.Contrasena == pass);

                if (vet != null)
                {
                    colaboradorActual = vet;
                    rolActual = "Veterinario";
                    MostrarBienvenida();
                    return true;
                }

                intentos++;
                Console.WriteLine($"\n   Credenciales incorrectas. Intento {intentos}/3");
                Console.WriteLine("   Presione ENTER para reintentar...");
                Console.ReadLine();
            }

            Console.WriteLine("\n   Cuenta bloqueada. Contacte al administrador.");
            return false;
        }

        static string LeerContrasena()
        {
            string pass = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    pass = pass.Substring(0, pass.Length - 1);
                    Console.Write("\b \b");
                }
                else if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return pass;
        }

        static void MostrarBienvenida()
        {
            Console.Clear();
            Console.WriteLine($"\n   Bienvenido(a), {colaboradorActual.Nombre}");
            Console.WriteLine($"   Rol detectado: {rolActual}");
            Console.WriteLine("\n   Presione ENTER para continuar...");
            Console.ReadLine();
        }

        static int MostrarMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("========================================================");
                Console.WriteLine("   SISTEMA DE CONTROL CLINICO VETERINARIO");
                Console.WriteLine($"   Usuario: {colaboradorActual.Nombre} | Rol: {rolActual}");
                Console.WriteLine("========================================================");
                Console.ResetColor();
                Console.WriteLine();

                Console.WriteLine("   1. Ver usuarios del sistema");

                if (rolActual == "Recepcionista")
                {
                    Console.WriteLine("   2. Registrar cliente");
                    Console.WriteLine("   3. Registrar mascota");
                    Console.WriteLine("   4. Crear cita");
                    Console.WriteLine("   5. Ver citas");
                    Console.WriteLine("   6. Cancelar cita");
                    Console.WriteLine("   9. Facturacion y pago");
                }

                if (rolActual == "Veterinario")
                {
                    Console.WriteLine("   7. Atender cita (consulta medica)");
                    Console.WriteLine("   8. Consultar historial clinico");
                    Console.WriteLine("  13. Ver clientes y mascotas registrados");
                }

                Console.WriteLine("  10. Generar resumen de control");
                Console.WriteLine("  11. Cerrar sesion");
                Console.WriteLine("  12. Salir del sistema");
                Console.WriteLine();
                Console.Write("   Seleccione una opcion: ");

                int.TryParse(Console.ReadLine(), out int opcion);

                switch (opcion)
                {
                    case 1: VerUsuarios(); break;
                    case 2:
                        if (rolActual == "Recepcionista") RegistrarCliente();
                        else AccesoDenegado();
                        break;
                    case 3:
                        if (rolActual == "Recepcionista") RegistrarMascota();
                        else AccesoDenegado();
                        break;
                    case 4:
                        if (rolActual == "Recepcionista") CrearCita();
                        else AccesoDenegado();
                        break;
                    case 5: ConsultarCitas(); break;
                    case 6:
                        if (rolActual == "Recepcionista") CancelarCita();
                        else AccesoDenegado();
                        break;
                    case 7:
                        if (rolActual == "Veterinario") AtenderCita();
                        else AccesoDenegado();
                        break;
                    case 8: ConsultarHistorial(); break;
                    case 9:
                        if (rolActual == "Recepcionista") GenerarFactura();
                        else AccesoDenegado();
                        break;
                    case 10: GenerarResumen(); break;
                    case 11:
                        return 11;
                    case 12:
                        return 12;

                    case 13:
                        if (rolActual == "Veterinario") VerPacientes();
                        else AccesoDenegado();
                        break;

                    default:
                        Console.WriteLine("\n   Opcion invalida.");
                        break;
                }
                if (opcion >= 1 && opcion <= 13)
                {
                    Console.WriteLine("\n   Presione ENTER para volver al menu...");
                    Console.ReadLine();
                }
            }
        }

        static void AccesoDenegado()
        {
            Console.WriteLine("\n   ACCESO DENEGADO. Su rol no permite esta opcion.");
        }

        static void VerUsuarios()
        {
            Console.Clear();
            Console.WriteLine("========================================================");
            Console.WriteLine("   USUARIOS DEL SISTEMA");
            Console.WriteLine("========================================================");

            Console.WriteLine("\n--- RECEPCIONISTAS ---");
            if (recepcionistas.Count == 0) Console.WriteLine("  No hay recepcionistas.");
            foreach (var r in recepcionistas)
                Console.WriteLine($"  {r} | Codigo: {r.CodigoEmpleado} | Turno: {r.Turno}");

            Console.WriteLine("\n--- VETERINARIOS ---");
            if (veterinarios.Count == 0) Console.WriteLine("  No hay veterinarios.");
            foreach (var v in veterinarios)
                Console.WriteLine($"  {v} | Codigo: {v.CodigoVet} | Esp: {v.Especialidad}");

            Console.WriteLine("\n--- CLIENTES ---");
            if (clientes.Count == 0) Console.WriteLine("  No hay clientes.");
            foreach (var c in clientes)
                Console.WriteLine($"  ID: {c.Id} | {c.Nombre} | DPI: {c.Dpi} | Mascotas: {c.Mascotas.Count}");

            Console.WriteLine("\n--- MASCOTAS ---");
            if (mascotas.Count == 0) Console.WriteLine("  No hay mascotas.");
            foreach (var m in mascotas)
                Console.WriteLine($"  ID: {m.IdMascota} | {m.Nombre} | {m.Especie} | Dueño: {m.Propietario?.Nombre}");
        }

        static void RegistrarCliente()
        {
            Console.Clear();
            Console.WriteLine("========================================================");
            Console.WriteLine("   REGISTRO DE CLIENTE");
            Console.WriteLine("========================================================");

            Console.Write("\n   Nombre: ");    string nombre = Console.ReadLine();
            Console.Write("   DPI: ");         string dpi = Console.ReadLine();
            Console.Write("   Telefono: ");    string tel = Console.ReadLine();
            Console.Write("   Email: ");       string email = Console.ReadLine();
            Console.Write("   Direccion: ");   string dir = Console.ReadLine();
            Console.Write("   NIT: ");         string nit = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(dpi))
            {
                Console.WriteLine("\n   ERROR: nombre y DPI son obligatorios.");
                return;
            }

            if (clientes.Any(c => c.Dpi == dpi))
            {
                Console.WriteLine("\n   ERROR: ya existe un cliente con ese DPI.");
                return;
            }

            Cliente nuevo = new Cliente
            {
                Id = contadorClientes++,
                Nombre = nombre,
                Dpi = dpi,
                Telefono = tel,
                Email = email,
                Direccion = dir,
                Nit = nit
            };

            clientes.Add(nuevo);
            clienteActual = nuevo;
            Console.WriteLine($"\n   OK: Cliente '{nombre}' registrado con ID {nuevo.Id}.");
        }

        static void RegistrarMascota()
        {
            Console.Clear();
            Console.WriteLine("========================================================");
            Console.WriteLine("   REGISTRO DE MASCOTA");
            Console.WriteLine("========================================================");

            if (clientes.Count == 0)
            {
                Console.WriteLine("\n   ERROR: primero registre un cliente (opcion 2).");
                return;
            }

            // Elegir cliente de la lista
            Console.WriteLine("\n   CLIENTES DISPONIBLES:");
            for (int i = 0; i < clientes.Count; i++)
                Console.WriteLine($"     {i + 1}. {clientes[i].Nombre} (DPI: {clientes[i].Dpi})");

            Console.Write("\n   Seleccione el dueño de la mascota: ");
            if (!int.TryParse(Console.ReadLine(), out int idxCli) ||
                idxCli < 1 || idxCli > clientes.Count)
            {
                Console.WriteLine("\n   Opcion invalida.");
                return;
            }
            Cliente dueno = clientes[idxCli - 1];

            Veterinario vetAsignado = veterinarios.FirstOrDefault();
            if (vetAsignado == null)
            {
                Console.WriteLine("\n   ERROR: no hay veterinarios registrados.");
                return;
            }

            Console.WriteLine($"\n   Dueño seleccionado: {dueno.Nombre}");
            Console.WriteLine($"   >> Veterinario asignado automaticamente: {vetAsignado.Nombre} ({vetAsignado.Especialidad})");
            Console.WriteLine();

            Console.Write("   Nombre mascota: ");                string nombre = Console.ReadLine();
            Console.Write("   Especie: ");                       string especie = Console.ReadLine();
            Console.Write("   Raza: ");                          string raza = Console.ReadLine();
            Console.Write("   Sexo: ");                          string sexo = Console.ReadLine();
            Console.Write("   Fecha nacimiento (dd/mm/yyyy): ");
            DateTime.TryParse(Console.ReadLine(), out DateTime fechaNac);
            Console.Write("   Peso (kg): ");
            double.TryParse(Console.ReadLine(), out double peso);

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("\n   ERROR: el nombre es obligatorio.");
                return;
            }

            Mascota nueva = new Mascota
            {
                IdMascota = contadorMascotas++,
                Nombre = nombre,
                Especie = especie,
                Raza = raza,
                Sexo = sexo,
                FechaNacimiento = fechaNac,
                Peso = peso,
                Propietario = dueno
                // Si tu clase Mascota tiene la propiedad, descomenta:
                // VeterinarioAsignado = vetAsignado
            };

            dueno.AgregarMascota(nueva);
            mascotas.Add(nueva);
            mascotaActual = nueva;
            clienteActual = dueno;

            Console.WriteLine($"\n   OK: Mascota '{nombre}' registrada para {dueno.Nombre}.");
            Console.WriteLine($"   Veterinario asignado: {vetAsignado.Nombre}");
        }

        static void CrearCita()
        {
            Console.Clear();
            Console.WriteLine("========================================================");
            Console.WriteLine("   CREAR NUEVA CITA");
            Console.WriteLine("========================================================");

            if (clientes.Count == 0)
            {
                Console.WriteLine("\n   ERROR: no hay clientes registrados. Registre uno primero.");
                return;
            }

            // Elegir cliente
            Console.WriteLine("\n   CLIENTES DISPONIBLES:");
            for (int i = 0; i < clientes.Count; i++)
                Console.WriteLine($"     {i + 1}. {clientes[i].Nombre} (DPI: {clientes[i].Dpi})");

            Console.Write("\n   Seleccione cliente: ");
            if (!int.TryParse(Console.ReadLine(), out int idxCli) ||
                idxCli < 1 || idxCli > clientes.Count)
            {
                Console.WriteLine("\n   Opcion invalida.");
                return;
            }
            Cliente cli = clientes[idxCli - 1];

            // Elegir mascota del cliente
            if (cli.Mascotas.Count == 0)
            {
                Console.WriteLine($"\n   ERROR: {cli.Nombre} no tiene mascotas registradas.");
                return;
            }

            Console.WriteLine($"\n   MASCOTAS DE {cli.Nombre}:");
            for (int i = 0; i < cli.Mascotas.Count; i++)
                Console.WriteLine($"     {i + 1}. {cli.Mascotas[i].Nombre} ({cli.Mascotas[i].Especie})");

            Console.Write("\n   Seleccione mascota: ");
            if (!int.TryParse(Console.ReadLine(), out int idxMas) ||
                idxMas < 1 || idxMas > cli.Mascotas.Count)
            {
                Console.WriteLine("\n   Opcion invalida.");
                return;
            }
            Mascota mas = cli.Mascotas[idxMas - 1];

            // Veterinario desde la lista
            if (veterinarios.Count == 0)
            {
                Console.WriteLine("\n   ERROR: no hay veterinarios registrados.");
                return;
            }

            Console.WriteLine("\n   VETERINARIOS DISPONIBLES:");
            for (int i = 0; i < veterinarios.Count; i++)
                Console.WriteLine($"     {i + 1}. {veterinarios[i].Nombre} - {veterinarios[i].Especialidad}");

            Console.Write("\n   Seleccione veterinario: ");
            if (!int.TryParse(Console.ReadLine(), out int idxVet) ||
                idxVet < 1 || idxVet > veterinarios.Count)
            {
                Console.WriteLine("\n   Opcion invalida.");
                return;
            }
            Veterinario vet = veterinarios[idxVet - 1];

            Console.Write("\n   Motivo: ");
            string motivo = Console.ReadLine();

            Console.Write("   Fecha (dd/mm/yyyy): ");
            DateTime.TryParse(Console.ReadLine(), out DateTime fecha);

            Console.Write("   Hora (HH:mm): ");
            string hora = Console.ReadLine();

            bool disponible = !citas.Any(c =>
                c.Veterinario.Id == vet.Id &&
                c.Fecha.Date == fecha.Date &&
                c.Hora == hora &&
                c.Estado != "Cancelada");

            if (!disponible)
            {
                Console.WriteLine($"\n   El/la {vet.Nombre} no esta disponible en ese horario.");
                return;
            }

            Cita nueva = new Cita
            {
                IdCita = contadorCitas++,
                Fecha = fecha,
                Hora = hora,
                Motivo = motivo,
                Cliente = cli,
                Mascota = mas,
                Veterinario = vet
            };

            citas.Add(nueva);
            Console.WriteLine($"\n   OK: Cita #{nueva.IdCita} creada para {cli.Nombre}.");
            Console.WriteLine($"   Mascota: {mas.Nombre} | Veterinario: {vet.Nombre} | Estado: {nueva.Estado}");
        }

        static void ConsultarCitas()
        {
            Console.Clear();
            Console.WriteLine("========================================================");
            Console.WriteLine("   CONSULTAR CITAS");
            Console.WriteLine("========================================================");
            Console.WriteLine("\n   1. Por fecha");
            Console.WriteLine("   2. Por cliente");
            Console.WriteLine("   3. Por veterinario");
            Console.WriteLine("   4. Todas");
            Console.Write("\n   Opcion: ");
            int.TryParse(Console.ReadLine(), out int op);

            List<Cita> resultado;
            switch (op)
            {
                case 1:
                    Console.Write("   Fecha (dd/mm/yyyy): ");
                    DateTime.TryParse(Console.ReadLine(), out DateTime f);
                    resultado = citas.Where(c => c.Fecha.Date == f.Date).ToList();
                    break;
                case 2:
                    Console.Write("   Nombre cliente: ");
                    string nc = Console.ReadLine();
                    resultado = citas.Where(c => c.Cliente.Nombre.Contains(nc, StringComparison.OrdinalIgnoreCase)).ToList();
                    break;
                case 3:
                    Console.Write("   Nombre veterinario: ");
                    string nv = Console.ReadLine();
                    resultado = citas.Where(c => c.Veterinario.Nombre.Contains(nv, StringComparison.OrdinalIgnoreCase)).ToList();
                    break;
                default:
                    resultado = citas;
                    break;
            }

            if (resultado.Count == 0) { Console.WriteLine("\n   Sin resultados."); return; }

            Console.WriteLine();
            foreach (var c in resultado)
            {
                Console.WriteLine($"   {c}");
                Console.WriteLine($"     Cliente: {c.Cliente.Nombre}");
                Console.WriteLine($"     Mascota: {c.Mascota.Nombre}");
                Console.WriteLine($"     Veterinario: {c.Veterinario.Nombre}");
                Console.WriteLine();
            }
        }

        static void CancelarCita()
        {
            Console.Clear();
            Console.WriteLine("========================================================");
            Console.WriteLine("   CANCELAR CITA");
            Console.WriteLine("========================================================");

            Console.Write("\n   ID de cita: ");
            int.TryParse(Console.ReadLine(), out int id);

            Cita c = citas.FirstOrDefault(x => x.IdCita == id);
            if (c == null) { Console.WriteLine("\n   Cita no encontrada."); return; }
            if (c.Estado == "Cancelada") { Console.WriteLine("\n   Ya esta cancelada."); return; }
            if (c.Estado == "Completada") { Console.WriteLine("\n   No se puede cancelar."); return; }

            Console.Write("\n   Confirma cancelacion? (s/n): ");
            if (Console.ReadLine().ToLower() == "s")
            {
                c.Cancelar();
                Console.WriteLine($"\n   OK: Cita #{id} cancelada.");
                Console.WriteLine("   Horario liberado. Cliente notificado.");
            }
        }

        static void AtenderCita()
        {
            Console.Clear();
            Console.WriteLine("========================================================");
            Console.WriteLine("   ATENDER CITA - CONSULTA MEDICA");
            Console.WriteLine("========================================================");

            Console.Write("\n   ID de cita: ");
            int.TryParse(Console.ReadLine(), out int id);

            Cita c = citas.FirstOrDefault(x => x.IdCita == id);
            if (c == null) { Console.WriteLine("\n   Cita no encontrada."); return; }
            if (c.Estado == "Completada") { Console.WriteLine("\n   Ya fue atendida."); return; }

            Console.WriteLine($"\n   Atendiendo cita de {c.Mascota.Nombre}");
            c.Mascota.MostrarHistorial();

            Console.Write("\n   Motivo de consulta: "); string motivo = Console.ReadLine();
            Consulta consulta = new Consulta { IdConsulta = contadorConsultas++, Motivo = motivo };

            Console.Write("   Diagnostico: ");           consulta.Diagnostico = Console.ReadLine();
            Console.Write("   Gravedad (Leve/Moderado/Grave): "); consulta.Gravedad = Console.ReadLine();
            Console.Write("   Tratamiento: ");           string tx = Console.ReadLine();
            Console.Write("   Duracion (dias): ");
            int.TryParse(Console.ReadLine(), out int dur);
            Console.Write("   Medicamentos (separados por coma): ");
            string meds = Console.ReadLine();

            consulta.RegistrarTratamiento(new Tratamiento
            {
                IdTratamiento = consulta.IdConsulta,
                Descripcion = tx,
                DuracionDias = dur,
                Medicamentos = meds
            });

            Console.Write("   Requiere receta? (s/n): ");
            if (Console.ReadLine().ToLower() == "s")
            {
                Console.Write("   Indicaciones: ");
                consulta.GenerarReceta(Console.ReadLine());
            }

            c.Mascota.AgregarConsulta(consulta);
            c.Completar();
            c.Consulta = consulta;

            Console.WriteLine($"\n   OK: Consulta #{consulta.IdConsulta} guardada.");
            Console.WriteLine($"   Cita #{c.IdCita} marcada como COMPLETADA.");
        }

        static void ConsultarHistorial()
        {
            Console.Clear();
            Console.WriteLine("========================================================");
            Console.WriteLine("   CONSULTAR HISTORIAL CLINICO");
            Console.WriteLine("========================================================");

            if (mascotas.Count == 0)
            {
                Console.WriteLine("\n   No hay mascotas registradas.");
                return;
            }

            Console.WriteLine("\n   MASCOTAS REGISTRADAS:");
            for (int i = 0; i < mascotas.Count; i++)
                Console.WriteLine($"     {i + 1}. {mascotas[i].Nombre} ({mascotas[i].Especie}) - Dueño: {mascotas[i].Propietario?.Nombre}");

            Console.Write("\n   Seleccione mascota: ");
            if (!int.TryParse(Console.ReadLine(), out int idx) || idx < 1 || idx > mascotas.Count)
            {
                Console.WriteLine("\n   Opcion invalida.");
                return;
            }

            Mascota m = mascotas[idx - 1];
            mascotaActual = m;
            m.MostrarHistorial();

            Console.Write("\n   Exportar a PDF? (s/n): ");
            if (Console.ReadLine().ToLower() == "s")
                Console.WriteLine($"\n   PDF del historial de {m.Nombre} generado.");
        }

        static void GenerarFactura()
        {
            Console.Clear();
            Console.WriteLine("========================================================");
            Console.WriteLine("   FACTURACION Y PAGO");
            Console.WriteLine("========================================================");

            if (clientes.Count == 0)
            {
                Console.WriteLine("\n   No hay clientes registrados.");
                return;
            }

            Console.WriteLine("\n   CLIENTES DISPONIBLES:");
            for (int i = 0; i < clientes.Count; i++)
                Console.WriteLine($"     {i + 1}. {clientes[i].Nombre} (DPI: {clientes[i].Dpi})");

            Console.Write("\n   Seleccione cliente: ");
            if (!int.TryParse(Console.ReadLine(), out int idxCli) ||
                idxCli < 1 || idxCli > clientes.Count)
            {
                Console.WriteLine("\n   Opcion invalida.");
                return;
            }
            Cliente cli = clientes[idxCli - 1];

            Console.Write("\n   Subtotal de servicios (Q): ");
            double.TryParse(Console.ReadLine(), out double subtotal);

            Factura factura = new Factura(cli, subtotal) { IdFactura = contadorFacturas++ };

            Console.WriteLine($"\n   Subtotal:        Q {factura.Subtotal:F2}");
            Console.WriteLine($"   Impuestos (16%): Q {factura.Impuestos:F2}");
            Console.WriteLine($"   TOTAL:           Q {factura.Total:F2}");

            Console.Write("\n   Aplica descuento? (s/n): ");
            if (Console.ReadLine().ToLower() == "s")
            {
                Console.Write("   Porcentaje: ");
                double.TryParse(Console.ReadLine(), out double desc);
                factura.AplicarDescuento(desc);
                Console.WriteLine($"   Nuevo total: Q {factura.Total:F2}");
            }

            Console.WriteLine("\n   Metodo de pago:");
            Console.WriteLine("     1. Efectivo");
            Console.WriteLine("     2. Tarjeta");
            Console.WriteLine("     3. Transferencia");
            Console.Write("   Opcion: ");
            int.TryParse(Console.ReadLine(), out int op);

            string metodo = op == 1 ? "Efectivo" : op == 2 ? "Tarjeta" : "Transferencia";
            Pago pago = new Pago { IdPago = contadorPagos++, Monto = factura.Total, MetodoPago = metodo };

            if (metodo == "Efectivo")
            {
                Console.Write("   Monto recibido (Q): ");
                double.TryParse(Console.ReadLine(), out double recibido);
                if (recibido < factura.Total)
                {
                    Console.WriteLine($"\n   Faltan Q {factura.Total - recibido:F2}. Pago cancelado.");
                    return;
                }
                pago.Cambio = recibido - factura.Total;
                Console.WriteLine($"   Cambio: Q {pago.Cambio:F2}");
            }
            else if (metodo == "Tarjeta")
            {
                Console.Write("   Numero de autorizacion: ");
                pago.NumAutorizacion = Console.ReadLine();
                Console.Write("   Ultimos 4 digitos: ");
                Console.ReadLine();
            }
            else
            {
                Console.Write("   Banco: ");
                pago.Banco = Console.ReadLine();
                Console.Write("   Numero de referencia: ");
                Console.ReadLine();
            }

            Console.Write("\n   Pago aprobado? (s/n): ");
            if (Console.ReadLine().ToLower() != "s")
            {
                Console.WriteLine("\n   Pago rechazado. Reintente.");
                return;
            }

            pago.ProcesarPago();
            factura.AgregarPago(pago);
            facturas.Add(factura);
            factura.Emitir();

            Console.WriteLine("\n   Inventario actualizado.");
            Console.WriteLine("   Pago registrado en el sistema.");
            Console.WriteLine($"   Estado de cuenta: {factura.Estado}");
            Console.WriteLine("   Factura enviada al cliente.");
        }

        static void GenerarResumen()
        {
            Console.Clear();
            Console.WriteLine("========================================================");
            Console.WriteLine("   RESUMEN DE CONTROL DEL SISTEMA");
            Console.WriteLine("========================================================");

            Console.WriteLine($"\n   Clientes registrados:    {clientes.Count}");
            Console.WriteLine($"   Mascotas registradas:    {mascotas.Count}");
            Console.WriteLine($"   Recepcionistas:          {recepcionistas.Count}");
            Console.WriteLine($"   Veterinarios:            {veterinarios.Count}");
            Console.WriteLine($"   Citas totales:           {citas.Count}");
            Console.WriteLine($"     - Programadas:         {citas.Count(c => c.Estado == "Programada")}");
            Console.WriteLine($"     - Completadas:         {citas.Count(c => c.Estado == "Completada")}");
            Console.WriteLine($"     - Canceladas:          {citas.Count(c => c.Estado == "Cancelada")}");
            Console.WriteLine($"   Facturas emitidas:       {facturas.Count}");
            Console.WriteLine($"   Ingresos totales:        Q {facturas.Sum(f => f.Total):F2}");
            Console.WriteLine("\n========================================================");
        }

        static void VerPacientes()
        {
            Console.Clear();
            Console.WriteLine("========================================================");
            Console.WriteLine("   CLIENTES Y MASCOTAS REGISTRADOS");
            Console.WriteLine("========================================================");

            if (clientes.Count == 0)
            {
                Console.WriteLine("\n   No hay clientes registrados.");
                return;
            }

            foreach (var c in clientes)
            {
                Console.WriteLine($"\n   CLIENTE: {c.Nombre} | DPI: {c.Dpi} | Tel: {c.Telefono}");
                if (c.Mascotas.Count == 0)
                {
                    Console.WriteLine("       (Sin mascotas registradas)");
                    continue;
                }

                foreach (var m in c.Mascotas)
                {
                    Console.WriteLine($"       - {m.Nombre} | {m.Especie} | {m.Raza} | Peso: {m.Peso} kg");
                }
            }
        }
    }
}