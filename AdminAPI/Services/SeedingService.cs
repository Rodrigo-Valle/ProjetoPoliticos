using System.Linq;
using AdminAPI.Data;
using AdminAPI.Models;
using AdminAPI.Models.Enum;

namespace AdminAPI.Services
{
    public class SeedingService
    {
        private readonly AppDbContext _database;

        public SeedingService(AppDbContext database)
        {
            _database = database;
        }

        public void Seed()
        {
            if (_database.Projetos.Any() || _database.Processos.Any() || _database.Politicos.Any() || _database.Partidos.Any())
            {
                return;
            }

            Partido pa1 = new Partido("PT", "Partido dos Trabalhadores");
            Partido pa2 = new Partido("PSL", "Partido Social Liberal");
            Partido pa3 = new Partido("MDB", "Movimento Democratico Brasileiro");
            Partido pa4 = new Partido("PSDB", "Partido da Social Democracia Brasileira");

            Politico p1 = new Politico("Gleisi Hoffmann", "74880444014", "Rua Qualquer uma, 123", "99965657878", pa1, "Url//Https://...", Cargo.deputado, true);

            Politico p2 = new Politico("Eduardo Suplicy", "74880444014", "Rua Qualquer uma, 123", "99965657878", pa1, "Url//Https://...", Cargo.vereador, false);

            Politico p3 = new Politico("Alexandre Padilha", "74880444014", "Rua Qualquer uma, 123", "99965657878", pa1, "Url//Https://...", Cargo.deputado, false);

            Politico p4 = new Politico("Rui Costa", "74880444014", "Rua Qualquer uma, 123", "99965657878", pa1, "Url//Https://...", Cargo.governador, false);

            Politico p5 = new Politico("Humberto Costa", "74880444014", "Rua Qualquer uma, 123", "99965657878", pa1, "Url//Https://...", Cargo.senador, false);

            Politico p6 = new Politico("Eduardo Bolsonaro", "74880444014", "Rua Qualquer uma, 123", "99965657878", pa2, "Url//Https://...", Cargo.deputado, true);

            Politico p7 = new Politico("Bia Kicis", "74880444014", "Rua Qualquer uma, 123", "99965657878", pa2, "Url//Https://...", Cargo.deputado, false);

            Politico p8 = new Politico("Flavio Bolsonaro", "74880444014", "Rua Qualquer uma, 123", "99965657878", pa2, "Url//Https://...", Cargo.senador, false);

            Politico p9 = new Politico("Jair Bolsonaro", "74880444014", "Rua Qualquer uma, 123", "99965657878", pa2, "Url//Https://...", Cargo.presidente, false);

            Politico p10 = new Politico("Ibaneis Rocha", "74880444014", "Rua Qualquer uma, 123", "99965657878", pa3, "Url//Https://...", Cargo.governador, false);

            Politico p11 = new Politico("Rodrigo Maia", "74880444014", "Rua Qualquer uma, 123", "99965657878", pa3, "Url//Https://...", Cargo.deputado, true);

            Politico p12 = new Politico("Renan Calheiros", "74880444014", "Rua Qualquer uma, 123", "99965657878", pa3, "Url//Https://...", Cargo.senador, false);

            Politico p13 = new Politico("Omar Aziz", "74880444014", "Rua Qualquer uma, 123", "99965657878", pa3, "Url//Https://...", Cargo.senador, false);

            Politico p14 = new Politico("Joao Doria", "74880444014", "Rua Qualquer uma, 123", "99965657878", pa4, "Url//Https://...", Cargo.governador, false);

            Politico p15 = new Politico("Aecio Neves", "74880444014", "Rua Qualquer uma, 123", "99965657878", pa4, "Url//Https://...", Cargo.deputado, true);

            Politico p16 = new Politico("Tasso Jereissati", "74880444014", "Rua Qualquer uma, 123", "99965657878", pa4, "Url//Https://...", Cargo.senador, false);

            Projeto j1 = new Projeto("1427/2015", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p2);

            Projeto j2 = new Projeto("1232/2017", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p2);

            Projeto j3 = new Projeto("1427/2019", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p2);

            Projeto j4 = new Projeto("41114/2019", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p2);

            Projeto j5 = new Projeto("1265/2015", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p3);

            Projeto j6 = new Projeto("1265/2015", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p3);

            Projeto j7 = new Projeto("1427/2015", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p5);

            Projeto j8 = new Projeto("1232/2017", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p5);

            Projeto j9 = new Projeto("1427/2019", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p6);

            Projeto j10 = new Projeto("41114/2019", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p7);

            Projeto j11 = new Projeto("1265/2015", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p10);

            Projeto j12 = new Projeto("1265/2015", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p10);

            Projeto j13 = new Projeto("1427/2015", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p10);

            Projeto j14 = new Projeto("1232/2017", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p11);

            Projeto j15 = new Projeto("1427/2019", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p11);

            Projeto j16 = new Projeto("41114/2019", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p11);

            Projeto j17 = new Projeto("1265/2015", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p13);

            Projeto j18 = new Projeto("1265/2015", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p15);



            Processo r1 = new Processo("1427/2015", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p1);

            Processo r2 = new Processo("1232/2017", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p1);

            Processo r3 = new Processo("1427/2019", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p1);

            Processo r4 = new Processo("41114/2019", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p1);

            Processo r5 = new Processo("1265/2015", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p3);

            Processo r6 = new Processo("1265/2015", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p4);

            Processo r7 = new Processo("1427/2015", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p4);

            Processo r8 = new Processo("1232/2017", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p6);

            Processo r9 = new Processo("1427/2019", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p6);

            Processo r10 = new Processo("41114/2019", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p7);

            Processo r11 = new Processo("1265/2015", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p8);

            Processo r12 = new Processo("1265/2015", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p8);

            Processo r13 = new Processo("1427/2015", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p11);

            Processo r14 = new Processo("1232/2017", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p11);

            Processo r15 = new Processo("1427/2019", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p11);

            Processo r16 = new Processo("41114/2019", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p14);

            Processo r17 = new Processo("1265/2015", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p14);

            Processo r18 = new Processo("1265/2015", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a pretium massa. Aenean enim velit, convallis in nisl.", p15);

            Usuario admin = new Usuario("Admin", UsuarioService.HashSenha("Gft2021"), true);

            Usuario user = new Usuario("Usuario", UsuarioService.HashSenha("Gft2021"), false);

            _database.Usuarios.AddRange(admin, user);
            _database.Partidos.AddRange(pa1, pa2, pa3, pa4);
            _database.Politicos.AddRange(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16);
            _database.Projetos.AddRange(j1, j2, j3, j4, j5, j6, j7, j8, j9, j10, j11, j12, j13, j14, j15, j16, j17, j18);
            _database.Processos.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14, r15, r16, r17, r18);
            _database.SaveChanges();
        }

    }
}