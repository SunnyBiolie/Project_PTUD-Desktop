using Project_PTUD_Desktop.ModelEntity.EntityDTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PTUD_Desktop.ModelEntity.EntityDAO
{
    public class FilmDAO
    {
        private static FilmDAO instance;
        public static FilmDAO Instance
        {
            get
            {
                if (instance == null) instance = new FilmDAO();
                return instance;
            }
            private set => instance = value;
        }
        private FilmDAO() { }


        public ObservableCollection<FilmDTO> GetMoreDetailListFilmFromListPhim(ObservableCollection<Phim> phims)
        {
            ObservableCollection<FilmDTO> list = new ObservableCollection<FilmDTO>();

            foreach (Phim phim in phims)
            {
                FilmDTO film = new FilmDTO(phim);
                list.Add(film);
            }

            return list;
        }
    }
}
