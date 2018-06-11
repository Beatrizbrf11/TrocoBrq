using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrocoBrq.Data.Context;
using TrocoBrq.Domain.Entities;

namespace TrocoBrq.Data.Migrations
{
    public static class DbInitializer
    {

        public static void Initialize(CoreContext context)
        {
            context.Database.EnsureCreated();

            if (context.Moeda.Any())
            {
                return;
            }

            var moedas = new Moeda[]
            {
                new Moeda{
                    Active = true
                    , CriadoPor = "Admin"
                    , DataCriadao = DateTime.Now
                    , NotasRetornadas = 0
                    , Quantidade = 5
                    , Valor = 100
                }
                , new Moeda{
                    Active = true
                    , CriadoPor = "Admin"
                    , DataCriadao = DateTime.Now
                    , NotasRetornadas = 0
                    , Quantidade = 5
                    , Valor = 10
                }
                , new Moeda{
                    Active =true
                    , CriadoPor = "Admin"
                    , DataCriadao = DateTime.Now
                    , NotasRetornadas = 0
                    , Quantidade = 5
                    , Valor = 50
                }
                , new Moeda{
                    Active = true
                    , CriadoPor = "Admin"
                    , DataCriadao = DateTime.Now
                    , NotasRetornadas = 0
                    , Quantidade = 5
                    , Valor = 5
                }
                , new Moeda{
                    Active = true
                    , CriadoPor = "Admin"
                    , DataCriadao = DateTime.Now
                    , NotasRetornadas = 0
                    , Quantidade = 5
                    , Valor = 1
                }
                  , new Moeda{
                    Active = true
                    , CriadoPor = "Admin"
                    , DataCriadao = DateTime.Now
                    , NotasRetornadas = 0
                    , Quantidade = 5
                    , Valor = (decimal)0.5
                }  
                  , new Moeda{
                    Active = true
                    , CriadoPor = "Admin"
                    , DataCriadao = DateTime.Now
                    , NotasRetornadas = 0
                    , Quantidade = 5
                    , Valor = (decimal)0.01
                }
                  , new Moeda{
                    Active = true
                    , CriadoPor = "Admin"
                    , DataCriadao = DateTime.Now
                    , NotasRetornadas = 0
                    , Quantidade = 5
                    , Valor = (decimal)0.05
                }
            };
            foreach (var s in moedas)
            {
                context.Moeda.Add(s);
            }
            context.SaveChanges();

            context.SaveChanges();
        }
    }
}
