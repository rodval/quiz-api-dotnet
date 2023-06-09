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

            };

            var questions = new Question[]
            {
                //peliculas
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
                //lvl2
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
                //lvl 3
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
                //Series
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
                //lvl 2
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
                //lvl 3
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
                //propiedad intelectual
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
                //lvl 2
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
                //lvl 3
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
