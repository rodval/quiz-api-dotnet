using Microsoft.AspNetCore.Identity;
using quiz_api_dotnet7.Models;
using quiz_api_dotnet7.Utilities;

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
                    Title = "Propiedad Intelectual",
                },
                new Category
                {
                    Id = 2,
                    Title = "Matematicas",
                },

                new Category
                {
                    Id = 3,
                    Title = "Ingles",
                },

                new Category
                {
                    Id = 4,
                    Title = "Ciencias",
                },


                new Category
                {
                    Id = 5,
                    Title = "sociales",
                }



            };

            var questions = new Question[]
            {
                new Question
                {
                    QuestionTitle = "¿Qué es el derecho de autor?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryId = 1,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Es un conjunto de normas jurídicas que protegen las creaciones originales.",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "son los derechos que tenemos básicamente por existir como seres humanos",
                            IsCorrect = false
                        },
                         new Answer
                        {
                            AnswerTitle = "Es rama del derecho que, en general, regula las relaciones civiles o privadas de las personas.",
                            IsCorrect = false
                        },
                          new Answer
                        {
                            AnswerTitle = "son el derecho fundamental humano por el que toda persona tiene el derecho al trabajo, a la libre elección de este.",
                            IsCorrect = false
                        }
                    }
                },
                new Question
                {
                    QuestionTitle = "¿Qué obras están protegidas por el derecho de autor? ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryId = 1,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Protegen a todas las obras originales de carácter literario, artístico o científico.",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Protegen los sistemas jurídicos nacionales, el sistema jurídico internacional y los sistemas jurídicos regionales.",
                            IsCorrect = false
                        },
                        
                        new Answer
                        {
                            AnswerTitle = "Protegen y proveen la respuesta a la explotación, el abuso, la negligencia, las prácticas nocivas y la violencia contra los niños",
                            IsCorrect = false
                        },
                         new Answer
                        {
                            AnswerTitle = "Protegen la conservación y el uso sostenible de la biodiversidad son elementos clave para avanzar hacia un modelo de economía verde y un desarrollo sostenible",
                            IsCorrect = false
                        }
                    }
                },
                new Question
                {
                    QuestionTitle = "¿Cómo se adquiere el derecho de autor? ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryId = 1,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Se adquiere automáticamente al crear una obra original.",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Se adquiere por nacimiento, sino mediante un proceso de aprendizaje, y su diferencia específica consiste en que o es práctica.",
                            IsCorrect = false
                        },
                          new Answer
                        {
                            AnswerTitle = "mediante una pluralidad de procesos cognitivos: percepción, memoria, experiencia, razonamiento.",
                            IsCorrect = false
                        }
                    }
                },
                new Question
                {
                    QuestionTitle = "¿Cuál es la duración del derecho de autor? ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryId = 1,
                    Answers = new Answer[] 
                    {
                        new Answer 
                        {
                            AnswerTitle = "Toda la vida",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Varía según el país y el tipo de obra.",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "1 año",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "1 lustro",
                            IsCorrect = false
                        }
                    }
                },
                new Question
                {
                    QuestionTitle = "¿Qué derechos tiene el titular del derecho de autor?  ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryId = 1,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Los derechos negociar con el propietario la renta del alquiler y la duración del contrato.",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Los derechos exclusivos de explotación y disposición de su obra.",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "libertad para adoptar, profesar, divulgar o seguir, inclusive de cambiar, la creencia religiosa o filosófica que más le agrade o desee.",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "derecho a que el Estado proteja los datos que se refieren a su vida privada y datos personales cuando se encuentren en posesión de particulares o de la autoridad.",
                            IsCorrect = false
                        }
                    }
                },
                new Question
                {
                    QuestionTitle = "¿Cuánto es 2+2?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryId = 2,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "4",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "5",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "9",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "10",
                            IsCorrect = false
                        }
                    }

                },
                 new Question
                 {
                    QuestionTitle = "¿Cuánto es 500x72?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryId = 2,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "36000",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "6300",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "74000",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "63000",
                            IsCorrect = false
                        }
                    }

                 },
                 new Question
                 {
                    QuestionTitle = "¿Cuánto es la raíz cuadrada de 120?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryId = 2,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "20.35",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "12.80",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "10.95",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "8.9",
                            IsCorrect = false
                        }
                    }

                 },
                  new Question
                  {
                    QuestionTitle = "¿Cuánto es 2000/475?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryId = 2,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "4.21",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "4.25",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "7.5",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "7.8",
                            IsCorrect = false
                        }
                    }

                  },
                   new Question
                   {
                    QuestionTitle = "¿Cuánto es 8+8?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryId = 2,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "16",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "32",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "24",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "56",
                            IsCorrect = false
                        }
                    }
                   },
                    new Question
                    {
                    QuestionTitle = "X way did Jimmi Hendrix play his guitar, left-handed or right-handed?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryId = 3,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "How",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "When",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Which",
                            IsCorrect = false
                        },
                    }

                    },
                     new Question
                     {
                    QuestionTitle = "How many Oscars X Joan Crawford win? ",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryId = 3,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Do",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Did",
                            IsCorrect = true
                        },

                        new Answer
                        {
                            AnswerTitle = "Done",
                            IsCorrect = false
                        },
                    }
                },
                     new Question
                     {
                    QuestionTitle = " X area of Paris was the setting of the film ‘Can - Can' ?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryId = 3,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Wish",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "What",
                            IsCorrect = true
                        },

                        new Answer
                        {
                            AnswerTitle = "Where",
                            IsCorrect = false
                        },
                    }
                },
                 new Question
                     {
                    QuestionTitle = " What is a Gametophobic bachelor afraid X",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryId = 3,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "On",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "By",
                            IsCorrect = false
                        },

                        new Answer
                        {
                            AnswerTitle = "Of",
                            IsCorrect = true
                        },
                    }
                },
                new Question
                     {
                    QuestionTitle = "Chives are the cousin of X Vegetables?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryId = 3,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "When",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Than",
                            IsCorrect = false
                        },

                        new Answer
                        {
                            AnswerTitle = "Which",
                            IsCorrect = true
                        },
                    }
                },
                new Question
            {
                    QuestionTitle = "¿Cómo se denomina la parte del cuerpo donde se juntan dos o más huesos?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryId = 4,
                    Answers = new Answer[]
              {

                 new Answer
                        {
                            AnswerTitle = "Articulaciones",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Tendones",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Cartílagos.",
                            IsCorrect = false
                        }

               }

             },
                new Question
            {
                    QuestionTitle = "¿Cómo se clasifican los animales según tengan columna vertebral o no?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryId = 4,
                    Answers = new Answer[]
              {

                 new Answer
                        {
                            AnswerTitle = "Animales vertebrados y animales invertebrados.",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Animales ovíparos o vivíparos.",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Animales carnívoros, herbívoros u omnívoros.",
                            IsCorrect = false
                        }

               }

             },
                new Question
            {
                    QuestionTitle = " ¿Cómo se llama el proceso por el cual las plantas elaboran su alimento?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryId = 4,
                    Answers = new Answer[]
              {

                 new Answer
                        {
                            AnswerTitle = " Fotosíntesis.",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = " Relación.",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = " Nutrición.",
                            IsCorrect = false
                        }

               }

             },
                new Question
            {
                    QuestionTitle = "¿Para qué sirve la raíz de lasplantas?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryId = 4,
                    Answers = new Answer[]
              {

                 new Answer
                        {
                            AnswerTitle = "Para absorber agua de la tierra.",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Para hacer la fotosíntesis.",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Para poder reproducirse.",
                            IsCorrect = false
                        }

               }

             },
                new Question
            {
                    QuestionTitle = " ¿Qué absorbe la planta a través de sus hojas?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryId = 4,
                    Answers = new Answer[]
              {

                 new Answer
                        {
                            AnswerTitle = "Oxígeno.",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = " Dióxido de carbono.",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Gases.",
                            IsCorrect = false
                        }

                }

                },
                new Question
            {
                    QuestionTitle = "¿Cuántos departamentos tiene El Salvador?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryId = 5,
                    Answers = new Answer[]
              {

                 new Answer
                        {
                            AnswerTitle = "10",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "5",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "15",
                            IsCorrect = false
                        },
                         new Answer
                        {
                            AnswerTitle = "14",
                            IsCorrect = true
                        }

                }

                },
                new Question
            {
                    QuestionTitle = " ¿En qué año El Salvador surge como país?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryId = 5,
                    Answers = new Answer[]
                {

                    new Answer
                        {
                            AnswerTitle = "1941",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "1950",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "1930",
                            IsCorrect = false
                        },
                         new Answer
                        {
                            AnswerTitle = "1960",
                            IsCorrect = false
                        }

                }

                },
                 new Question
                 {
                    QuestionTitle = "¿Qué cultivo impulso al general Gerardo barrios?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryId = 5,
                    Answers = new Answer[]
                    {

                    new Answer
                        {
                            AnswerTitle = "Caña de azúcar",
                            IsCorrect = false
                        },
                        new Answer
                            {
                            AnswerTitle = "El Café",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Algodón",
                            IsCorrect = false
                        },
                         new Answer
                            {
                            AnswerTitle = "El Maiz",
                            IsCorrect = false
                         }

                    }

                },
                  new Question
                  {
                    QuestionTitle = "¿Qué cultivo impulso al general Gerardo barrios?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryId = 5,
                    Answers = new Answer[]
                    {

                    new Answer
                        {
                            AnswerTitle = "Francisco Menéndez",
                            IsCorrect = false
                        },
                        new Answer
                            {
                            AnswerTitle = "Maximiliano Hernández Martínez",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Alfredo Cristiani",
                            IsCorrect = false
                        },
                         new Answer
                            {
                            AnswerTitle = "Elías Antonio Saca",
                            IsCorrect = false
                         }

                    }

                  },
                  new Question
                  {
                    QuestionTitle = "¿En qué año inicio la guerra civil en El Salvador ?",
                    QuestionType = QuestionType.MultipleChoice,
                    CategoryId = 5,
                    Answers = new Answer[]
                    {

                    new Answer
                        {
                            AnswerTitle = "1981",
                            IsCorrect = true
                        },
                        new Answer
                            {
                            AnswerTitle = "1999",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "1950",
                            IsCorrect = false
                        },
                         new Answer
                            {
                            AnswerTitle = "1955",
                            IsCorrect = false
                         }

                    }

                  },


            };

            context.Users.AddRange(users);
            context.Categories.AddRange(categories);
            context.Questions.AddRange(questions);
            context.SaveChanges();
        }
    }
}
