using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Caso_Estudio.Models;
using System.Data.Entity;

namespace Caso_Estudio.DAL
{
    public class VideoClubInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<VideoClubContext>
    {
        protected override void Seed(VideoClubContext context)
        {
            var videoclub = new List<VideoClub>
            {
                new VideoClub { VideoClubID = 1, Name="Alicante",   Address="Alicante numero 10",   City="Alicante",    Peliculas= null, Zip="03725"},
                new VideoClub { VideoClubID = 2, Name="Madrid",     Address="Madrid numero 20",     City="Madrid",      Peliculas= null, Zip="22080"},
                new VideoClub { VideoClubID = 3, Name="Valencia",   Address="Valencia numero 30",   City="Valencia",    Peliculas= null, Zip="46022"},
                new VideoClub { VideoClubID = 4, Name="Murcia",     Address="Murcia numero 40",     City="Murica",      Peliculas= null, Zip="56789"},
                new VideoClub { VideoClubID = 5, Name="Sevilla",    Address="Sevilla numero 50",    City="Sevilla",     Peliculas= null, Zip="87654"}
            };
            
            var peliculas = new List<Pelicula>
            {
                new Pelicula { PeliculaID =1 , Name="Pulp Fiction",         Director="Quentin Tarantino",   ReleaseDate=new DateTime(1994, 1, 18), Price=3.00, Alquiler=null, VideoClub=videoclub[0]  },
                new Pelicula { PeliculaID =2 , Name="El padrino",           Director="Francis Ford Coppola",ReleaseDate=new DateTime(1972, 2, 19), Price=3.00, Alquiler=null, VideoClub=videoclub[0]  },
                new Pelicula { PeliculaID =3 , Name="La vida es bella",     Director="Roberto Benigni",     ReleaseDate=new DateTime(1997, 3, 17), Price=3.00, Alquiler=null, VideoClub=videoclub[1]  },
                new Pelicula { PeliculaID =4 , Name="El club de la lucha",  Director="David Fincher",       ReleaseDate=new DateTime(1999, 4, 14), Price=3.00, Alquiler=null, VideoClub=videoclub[2]  },
                new Pelicula { PeliculaID =5 , Name="Cadena perpetua",      Director="Frank Darabont",      ReleaseDate=new DateTime(1994, 5, 15), Price=3.00, Alquiler=null, VideoClub=videoclub[3]  },
                new Pelicula { PeliculaID =6 , Name="La lista de Schindler",Director="Steven Spielberg",    ReleaseDate=new DateTime(1993, 6, 16), Price=3.00, Alquiler=null, VideoClub=videoclub[4]  },
                new Pelicula { PeliculaID =7 , Name="La naranja mecánica",  Director="Stanley Kubrick",     ReleaseDate=new DateTime(1971, 7, 13), Price=3.00, Alquiler=null, VideoClub=videoclub[2]  },
                new Pelicula { PeliculaID =8 , Name="El padrino. Parte II", Director="Francis Ford Coppola",ReleaseDate=new DateTime(1974, 8, 12), Price=3.00, Alquiler=null, VideoClub=videoclub[3]  },
                new Pelicula { PeliculaID =9 , Name="Amelie",               Director="Jean-Pierre Jeunet",  ReleaseDate=new DateTime(2001, 9, 11), Price=3.00, Alquiler=null, VideoClub=videoclub[1]  }
            };

            for (int i = 0; i < videoclub.Count; i++)
            {
                var list = new List<Pelicula>();
                for (int j = 0; j < peliculas.Count; j++)
                {
                    if (videoclub[i].VideoClubID == peliculas[j].VideoClub.VideoClubID)
                    {
                        list.Add(peliculas[j]);
                    }
                }
                videoclub[i].Peliculas = list;
            }

            //guardamos el contexto de el video club y la pelicula
            videoclub.ForEach(s => context.VideoClubs.Add(s));
            context.SaveChanges();
            peliculas.ForEach(s => context.Peliculas.Add(s));
            context.SaveChanges();

            var socios = new List<Socio>
            {
                new Socio { SocioID=1, Name="Julian Rodriguez",     Age=20},
                new Socio { SocioID=2, Name="Alberto Alonzo",       Age=21},
                new Socio { SocioID=3, Name="Rosa Peletti",         Age=22},
                new Socio { SocioID=4, Name="Salvador Lucas",       Age=23},
                new Socio { SocioID=5, Name="Cristiano Ronaldo",    Age=24}
            };
            socios.ForEach(s => context.Socios.Add(s));
            context.SaveChanges();

            var admins = new List<Administrador>
            {
                new Administrador {AdministradorID=1, Name="Marco" },
                new Administrador {AdministradorID=2, Name="Juan Manuel" }
            };
            admins.ForEach(s => context.Administradores.Add(s));
            context.SaveChanges();

                
        }
    }
}