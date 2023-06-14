using Microsoft.AspNetCore.Identity;
using quiz_api_dotnet7.Models;
using quiz_api_dotnet7.Models.Categories;
using quiz_api_dotnet7.Models.Users;
using quiz_api_dotnet7.Models.UsersQuizzes;
using quiz_api_dotnet7.Utilities;
using System.Drawing;
using System.Xml.Linq;

namespace quiz_api_dotnet7.Data
{
    public static class DbInitializer
    {
        public static void Initialize(QuizContext context)
        {
            if (context.Users.Any()
                && context.Categories.Any()
                && context.Questions.Any())
            {
                return;   // DB has been seeded
            }

            var hasher = new PasswordHasher<User>();

            var users = new User[]
            {
                new User
                {
                    FirstName = "Rodrigo",
                    LastName = "Valladares",
                    UserName = "rod",
                    Email = "rodrigovalladares@gmail.com",
                    Password = hasher.HashPassword(null, "P@ssword1"),
                    Role = UserRoleType.Administrator
                },
                new User
                {
                    FirstName = "Daniel",
                    LastName = "Sanchez",
                    UserName = "dan",
                    Email = "danielsanchez@gmail.com",
                    Password = hasher.HashPassword(null, "P@ssword1"),
                    Role = UserRoleType.Customer
                }
            };

            var categories = new Category[]
            {
                new Category
                {
                    Id = 1,
                    Title = "Peliculas",
                    Image = "/Img/matematicas.png",
                },
                new Category
                {
                    Id = 2,
                    Title = "Series",
                    Image = "/Img/matematicas.png",
                },
                new Category
                {
                    Id = 3,
                    Title = "Propiedad Intelectual",
                    Image = "/Img/lenguaje.png",
                },
                new Category
                {
                    Id = 4,
                    Title = "Musica",
                    Image = "/Img/matematicas.png",
                },
                new Category
                {
                    Id = 5,
                    Title = "Juegos",
                    Image = "/Img/matematicas.png",
                },
            };

            var categoryQuizzes = new CategoryQuiz[]
            {
                new CategoryQuiz
                {
                    Id = 1,
                    Level = 1,
                    CategoryId = 1,
                },
                new CategoryQuiz
                {
                    Id = 2,
                    Level = 2,
                    CategoryId = 1,
                },
                new CategoryQuiz
                {
                    Id = 3,
                    Level = 3,
                    CategoryId = 1,
                },
                new CategoryQuiz
                {
                    Id = 4,
                    Level = 1,
                    CategoryId = 2,
                },
                new CategoryQuiz
                {
                    Id = 5,
                    Level = 2,
                    CategoryId = 2,
                },
                new CategoryQuiz
                {
                    Id = 6,
                    Level = 3,
                    CategoryId = 2,
                },
                new CategoryQuiz
                {
                    Id = 7,
                    Level = 1,
                    CategoryId = 3,
                },
                new CategoryQuiz
                {
                    Id = 8,
                    Level = 2,
                    CategoryId = 3,
                },
                new CategoryQuiz
                {
                    Id = 9,
                    Level = 3,
                    CategoryId = 3,
                },
                new CategoryQuiz
                {
                    Id = 10,
                    Level = 1,
                    CategoryId = 4,
                },
                new CategoryQuiz
                {
                    Id = 11,
                    Level = 2,
                    CategoryId = 4,
                },
                new CategoryQuiz
                {
                    Id = 12,
                    Level = 3,
                    CategoryId = 4,
                },
                new CategoryQuiz
                {
                    Id = 13,
                    Level = 1,
                    CategoryId = 5,
                },
                new CategoryQuiz
                {
                    Id = 14,
                    Level = 2,
                    CategoryId = 5,
                },
                new CategoryQuiz
                {
                    Id = 15,
                    Level = 3,
                    CategoryId = 5,
                },
            };

            var questions = new Question[]
            {
                new Question
                {
                    QuestionTitle = "La película \"Titanic\" fue dirigida por James Cameron.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 1,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Falso",
                            IsCorrect = false
                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "¿Cuál de las siguientes películas fue dirigida por Quentin Tarantino?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 1,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "\"The Shawshank Redemption",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "\"Pulp Fiction",
                            IsCorrect = true
                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "\"El Padrino\" es una película dirigida por Steven Spielberg.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 1,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = true
                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "\"Jurassic Park\" fue lanzada en el año 1993.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 1,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false
                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "\"Harry Potter y la piedra filosofal\" es la primera película de la serie de Harry Potter.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 1,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false
                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "\"El Rey León\" es una película de animación de Disney.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 1,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false
                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "\"El Señor de los Anillos: El retorno del rey\" ganó el Óscar a la Mejor Película. ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 1,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false
                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "\"Titanic\" es una película basada en hechos reales.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 2,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false
                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "\"Avatar\" fue dirigida por James Cameron.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 2,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false
                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "\"Matrix\" es una película de ciencia ficción protagonizada por Keanu Reeves. .",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 2,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false
                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "\"La La Land\" es una película de acción y aventura.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 2,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = true
                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "\"El resplandor\" fue dirigida por Alfred Hitchcock.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 2,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = true
                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "E.T., el extraterrestre\" es una película de Spielberg que se estrenó en 1982",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 2,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = true
                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "La La Land\" ganó el Óscar a la Mejor Película en 2017.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 2,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = true
                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "Los Vengadores\" es una película de Marvel que reúne a varios superhéroes. ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 3,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false
                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "\"El caballero de la noche asciende\" es la tercera película de la trilogía de Batman dirigida por Christopher Nolan.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 3,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = true

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "\"Toy Story\" es una película de animación de Pixar.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 3,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "\"Titanic\" es la película más taquillera de todos los tiempos.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 3,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = true

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "El actor Tom Hanks ha ganado un Premio de la Academia en dos ocasiones.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 3,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "La película \"El Padrino\" fue dirigida por Martin Scorsese.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 3,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = true

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "El personaje de Darth Vader aparece en todas las películas de la saga \"Star Wars\".",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 3,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = true

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "\"Attack on Titan\" es un anime basado en un manga escrito por Hajime Isayama. ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 4,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "En el anime \"One Piece\", el protagonista es Monkey D. Luffy, un pirata en busca del tesoro más grande del mundo. ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 4,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "La serie \"Friends\" se desarrolla en la ciudad de Nueva York y sigue las vidas de un grupo de amigos. ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 4,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "\"Naruto\" es un anime que sigue las aventuras de un joven ninja llamado Sasuke Uchiha.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 4,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = true

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "En el anime \"Death Note\", un estudiante de secundaria encuentra un cuaderno que le permite matar a cualquier persona escribiendo su nombre. ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 4,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "La serie \"Stranger Things\" se desarrolla en un mundo postapocalíptico invadido por zombis.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 4,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = true

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "El anime \"Dragon Ball Z\" sigue las aventuras de un niño llamado Goku mientras protege la Tierra de amenazas extraterrestres.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 4,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "La serie \"Breaking Bad\" sigue la historia de un profesor de química que se convierte en un respetado científico.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 5,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = true

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "En el anime \"Fullmetal Alchemist\", dos hermanos alquimistas buscan la Piedra Filosofal para restaurar sus cuerpos.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 5,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "\"The Walking Dead\" es una serie que narra las aventuras de un grupo de supervivientes en un mundo postapocalíptico lleno de zombis.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 5,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "El anime \"One Punch Man\" cuenta la historia de un superhéroe extremadamente poderoso que puede derrotar a cualquier enemigo con un solo golpe.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 5,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "La serie \"Game of Thrones\" se basa en una serie de libros escritos por George R.R. Martin.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 5,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "En el anime \"My Hero Academia\", la mayoría de las personas tienen superpoderes conocidos como \"Quirks\". ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 5,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "La serie \"Sherlock\" está basada en los libros de Arthur Conan Doyle sobre el famoso detective Sherlock Holmes. ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 5,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "En el anime \"Sword Art Online\", los jugadores quedan atrapados en un juego de realidad virtual y deben luchar por su supervivencia.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 6,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "La serie \"The Office\" es un falso documental que sigue las vidas de los empleados de una oficina de papel en Scranton, Pennsylvania.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 6,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "El anime \"Cowboy Bebop\" sigue las aventuras de un grupo de cazarrecompensas en el futuro. ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 6,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "La serie \"Stranger Things\" fue creada por los hermanos Duffer. ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 6,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "En el anime \"Attack on Titan\", los seres humanos luchan contra gigantes devoradores de personas. ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 6,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "La serie \"The Big Bang Theory\" sigue la vida de un grupo de amigos científicos que viven juntos.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 6,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = true

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "En el anime \"One Piece\", Monkey D. Luffy es un cazador de tesoros en busca del mapa del tesoro más buscado.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 6,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = true

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "La propiedad intelectual se refiere a los derechos legales sobre obras creativas e inventivas",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 7,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "El copyright es un tipo de protección legal para obras literarias, artísticas y musicales. ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 7,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "Las marcas registradas protegen los nombres, logotipos y símbolos que identifican a productos o servicios.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 7,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "Las ideas no pueden ser protegidas por la propiedad intelectual. ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 7,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = true

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "El plazo de protección de los derechos de autor es de 100 años desde la muerte del autor. ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 7,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = true

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "Las patentes protegen invenciones y descubrimientos nuevos y útiles. ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 7,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "El fair use es una excepción en el derecho de autor que permite el uso limitado de material protegido sin permiso del titular de los derechos. ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 7,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "El registro de una marca es válido internacionalmente en todos los países. ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 8,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = true

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "El dominio público se refiere a obras que han perdido su protección de derechos de autor y pueden ser utilizadas libremente. ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 8,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "El plagio se refiere a la copia no autorizada de una obra protegida por derechos de autor.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 8,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "Las patentes tienen una duración de 20 años a partir de la fecha de presentación de la solicitud. ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 8,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "Las obras derivadas son creaciones basadas en una obra existente, pero con suficientes cambios para ser consideradas originales. ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 8,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "Los derechos morales protegen el vínculo entre el autor y su obra, incluyendo el derecho a ser reconocido como autor y el derecho a la integridad de la obra. ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 8,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "El registro de derechos de autor es necesario para obtener protección legal. ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 8,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = true

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "Las licencias Creative Commons son un tipo de licencia que permite a los creadores otorgar ciertos derechos de uso a otras personas",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 9,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "El secreto comercial protege la información confidencial que da a una empresa una ventaja competitiva.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 9,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = true

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "Las ideas son automáticamente protegidas por derechos de autor.",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 9,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = true

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "El término \"marca comercial\" y \"marca registrada\" son sinónimos. ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 9,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "La protección de derechos de autor se aplica automáticamente tan pronto ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 9,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "Las obras anónimas no pueden estar protegidas por derechos de autor. ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 9,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = true

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "Las patentes pueden ser otorgadas para métodos de negocio y software. ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 9,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "falso",
                            IsCorrect = false

                        },
                    }
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es el instrumento musical más antiguo del mundo?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 10,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "La flauta",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "El tambor",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "La Guitarra",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "El bajo",
                            IsCorrect = false
                        },
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Qué famoso compositor alemán escribió la Novena Sinfonía?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 10,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Ludwig van Beethoven",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Wolfgang Amadeus Mozart",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Johann Sebastian Bach",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Frédéric Chopin",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es el género musical originario de Jamaica que fusiona el ska y el rocksteady?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 10,
                    Answers = new Answer[]
                    {
                        new Answer
                            {
                                AnswerTitle = "El reggae",
                                IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "El reggaeton",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Samba",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Lambada",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Qué cantante es conocido como El Rey del Pop?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 10,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Michael Jackson",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Madona",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Héctor Lavoe",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Don Omar",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Qué instrumento toca Yo-Yo Ma?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 10,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "El violonchelo",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Cimitarra",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Erhu",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Shamisen",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es la banda de rock liderada por Mick Jagger?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 10,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "The Rolling Stones",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "The Beatles",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Metallica",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Pink Floyd",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Qué instrumento es conocido como el rey de los instrumentos?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 10,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "El órgano",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "La guitarra eléctrica",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "La batería",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Bajo eléctrico",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es el género musical que se caracteriza por su ritmo sincopado y su origen en Nueva Orleans?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 10,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "El Jazz",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Rock and roll",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Blues",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "country",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Quién compuso la famosa ópera \"La Traviata\"?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 10,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Giuseppe Verdi",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Christoph Willibald Gluck",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Domenico Cimarosa",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Giacomo Meyerbeer",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Qué banda británica alcanzó fama mundial con su álbum Sgt. Pepper's Lonely Hearts Club Band ?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 10,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "The Beatles",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Led Zeppelin",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Pink Floyd",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Queen",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Qué cantante interpretó la canción \"Like a Prayer\"?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 11,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Madonna",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Céline Dion",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Mariah Carey",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Beyoncé",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es el nombre completo de la cantante conocida como Lady Gaga?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 11,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Stefani Joanne Angelina Germanotta",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Giselle Knowles",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Destiny Hope",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Carolina Giraldo Navarro",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es el género musical originario de Brasil que se caracteriza por su ritmo y sensualidad?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 11,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "La samba",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Lambada",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Merengue",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Reggaeton",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es el compositor más famoso del periodo barroco?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 11,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Johann Sebastian Bach",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Ludwig van Beethoven",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Wolfgang Amadeus Mozart",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Frédéric Chopin",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Qué instrumento es fundamental en la música flamenca?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 11,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "La guitarra",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "El Bajo",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Las Maracas",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Las Castañas",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Qué banda de rock británica escribió la canción \"Bohemian Rhapsody\"?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 11,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Queen",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "The Beatles",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Pink Floyd",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Led Zeppelin",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Qué instrumento toca Carlos Santana?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 11,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Guitarra",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Bajo",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Maracas",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Trompeta",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es el nombre artístico de la cantante y actriz Stefani Germanotta?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 11,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Lady Gaga",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Mariah Carey",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Aretha Franklin",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Whitney Houston",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Qué cantante de soul y R&B es conocida como \"The Queen of Soul\"?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 11,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Aretha Franklin",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Christina Aguilera",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Tina Turner",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Ella Fitzgerald",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Quién es el compositor de la famosa obra \"El Danubio Azul\"?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 11,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Johann Strauss II",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Richard Wagner",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Antonín Dvořák",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Piotr Ilich Chaikovski",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Qué instrumento de viento metal es conocido como \"el rey de los instrumentos de viento\"?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 11,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "La trompeta",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "La tuba",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Trombón",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Saxofón",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es el género musical que surgió en Jamaica a finales de la década de 1960 y popularizó Bob Marley?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 11,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "El reggae",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "El reggaeton",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Jazz",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Blues",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Qué cantante británico es conocido por su alter ego Ziggy Stardust?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 11,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "David Bowie",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Freddie Mercury",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Elton John",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "John Lennon",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es el instrumento principal en una orquesta sinfónica?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 11,
                    Answers = new Answer[]  
                    {
                        new Answer
                        {
                            AnswerTitle = "La viola",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "El violin",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "La Tuba",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "La Flauta",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es el nombre del famoso grupo de rock británico conocido por su álbum \"Stairway to Heaven\" y su icónica canción \"Kashmir\"?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 11,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Led Zeppelin",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Guns N' Roses",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "The Beatles",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Queen",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es el nombre completo del famoso guitarrista de rock, conocido por su interpretación en la banda Guns N' Roses?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 11,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Slash",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Freddie Mercury",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Paul Stanley",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Ace Frehley",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Qué famoso músico y compositor austriaco fue un prodigio en el piano desde temprana edad y compuso numerosas sinfonías y sonatas?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 11,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Wolfgang Amadeus Mozart",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Johann Sebastian Bach",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Ludwig Van Beethoven",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Antonio Vivaldi",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Qué género musical se originó en la ciudad de Nueva Orleans a principios del siglo XX y se caracteriza por su ritmo alegre y sus improvisaciones?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 11,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Jazz",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Country",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Blues",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Rap",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "Qué famosa cantante estadounidense es conocida como la \"Reina del Soul\" y es famosa por canciones como \"Respect\" y \"Chain of Fools\"",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 11,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Aretha Franklin",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Whitney Houston",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Tina Turner",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Patti LaBelle",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es el género musical que combina elementos del rock y el hip-hop, y se originó en los barrios afroamericanos de Nueva York en la década de 1970?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 11,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "El rap",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "rock",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "hip-hop",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Disco",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿En qué año se lanzó el videojuego \"Super Mario Bros.\"?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 12,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "1985",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "1980",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "1978",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "1979",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es el nombre del personaje principal de la saga de videojuegos \"The Legend of Zelda\"?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 12,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Link",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Ganon",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Zelda",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Impa",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es el nombre del fontanero italiano y hermano de Mario que protagoniza su propio videojuego?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 12,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Luigi",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Wario",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Waluigi",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Bowser",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es el nombre del fontanero italiano y hermano de Mario que protagoniza su propio videojuego?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 12,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Donkey Kong.",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Diddy Kong.",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "King Kong",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Bowser",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿En qué año se lanzó el videojuego \"Pokémon Red and Green\" en Japón?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 12,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "1996.",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "1993.",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "1998",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "1997",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es el nombre del personaje icónico y mascota de SEGA?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 12,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Sonic.",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Rocket.",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Crash Bandicoot",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Ratchet",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es el nombre del popular juego de construcción y exploración en un mundo abierto creado por Mojang Studios?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 12,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Minecraft",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Zelda",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Final Fantasy",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "League Of Legends",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿En qué año se lanzó el videojuego \"Tetris\"?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 12,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "1984",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "1985",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "1987",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "1990",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es el nombre del personaje principal en la saga de videojuegos \"Final Fantasy VII\"?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 12,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Cloud Strife",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Tommy Vercetti",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Link",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Samus Aran",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es el nombre del famoso erizo azul que protagoniza una serie de videojuegos?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 12,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Sonic",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Crash Bandicoot",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Ratchet",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Yoshi",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿En qué año se lanzó el videojuego \"Grand Theft Auto V\"?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 13,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "2013",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "2016",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "2018",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "2012",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es el nombre del personaje principal en la saga de videojuegos \"The Witcher\"?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 13,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Geralt de Rivia",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Samus Aran",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Solid Snake",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Nathan Drake",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es el nombre del popular juego de battle royale desarrollado por Epic Games?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 13,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Fortnite",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "WarZone ",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "PlayerUnknown's Battlegrounds",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Free Fire",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿En qué año se lanzó el videojuego \"World of Warcraft\"?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 13,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "2004",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "2006",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "2000",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "2002",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es el nombre del personaje principal en la saga de videojuegos \"Uncharted\"?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 13,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Nathan Drake",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Lara Croft",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Cloud Strife",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Axel Steel",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿En qué año se lanzó el videojuego \"The Legend of Zelda: Ocarina of Time\"?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 13,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "1998",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "1996",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "1992",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "1994",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es el nombre del personaje principal en la saga de videojuegos \"Assassin's Creed\" más conocido?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 13,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Desmond Miles.",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Nathan Drake",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Dante",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Marcus Fenix",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es el nombre del popular juego de plataformas en 3D desarrollado por Naughty Dog?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 13,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Crash Bandicoot",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Sonic",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Astro Bot Rescue Mission",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Sackboy A Big Adventure",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿En qué año se lanzó el videojuego \"Mortal Kombat\"?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 13,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "1992",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "1996",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "1994",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "1998",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es el nombre del personaje principal en la saga de videojuegos \"Metal Gear Solid\"?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 13,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Solid Snake",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Master Chief",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Ryu",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Arthur Morgan",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es el nombre del popular juego de disparos en primera persona desarrollado por Valve?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 14,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Counter-Strike",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Valorant",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Battlefield",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Call of Duty",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿En qué año se lanzó el videojuego \"The Elder Scrolls V: Skyrim\"?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 14,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "2008",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "2011",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "2009",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "2013",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál fue el primer videojuego de la serie \"Final Fantasy\" lanzado en 1987?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 14,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Final Fantasy I",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Final Fantasy 0",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Final Fantasy Tactics",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Final Fantasy Anthology",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es el nombre del personaje principal en la saga de videojuegos \"God of War\"?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 14,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Kratos",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Zeus",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Ares",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Hades",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es el nombre del popular juego de aventuras y acción en mundo abierto desarrollado por Rockstar Games?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 14,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Red Dead Redemption",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "GTAV",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Bully",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "LA.Noire",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿En qué año se lanzó el videojuego \"Super Smash Bros. Ultimate\" para la consola Nintendo Switch?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 14,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "2018",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "2016",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "2017",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "2015",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es el nombre del personaje principal en la saga de videojuegos \"Halo\"?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 14,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Master Chief ",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Marcus Fenix",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Nathan Drake",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Arthur Morgan",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es el nombre del popular juego de estrategia en tiempo real desarrollado por Blizzard Entertainment?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 14,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "StarCraft",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Hearthstone",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Diablo",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "World of Warcraft",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿En qué año se lanzó el videojuego \"The Last of Us\" para la consola PlayStation 3?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 14,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "2013",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "2014",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "2015",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "2012",
                            IsCorrect = false
                        }
                    },
                },
                new Question
                {
                    QuestionTitle = "¿En qué año se lanzó el videojuego The Legend of Zelda Breath of The Wild?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryQuizId = 14,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "2017",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "2018",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "2016",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "2013",
                            IsCorrect = false
                        }
                    },
                },
            };

            var userQuizzes = new UserQuiz[]
            {
                new UserQuiz
                {
                    Id = 1,
                    CategoryQuizId= 1,
                    UserId = 1,
                    Score = 10,
                },
                new UserQuiz
                {
                    Id = 2,
                    CategoryQuizId= 1,
                    UserId = 2,
                    Score = 5,
                },
                new UserQuiz
                {
                    Id = 3,
                    CategoryQuizId= 2,
                    UserId = 2,
                    Score = 7,
                },
            };

            context.Users.AddRange(users);
            context.Categories.AddRange(categories);
            context.CategoryQuizzes.AddRange(categoryQuizzes);
            context.Questions.AddRange(questions);
            context.UserQuizzes.AddRange(userQuizzes);
            context.SaveChanges();
        }
    }
}
