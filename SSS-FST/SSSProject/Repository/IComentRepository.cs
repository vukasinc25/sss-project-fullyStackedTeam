using SSSProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSSProject.Repository
{
    internal interface IComentRepository
    {
        List<Coments> GetAll();
        Coments GetById(int id);
        int Add(Coments coments);
        void Update(int id, Coments coments);
        void Delete(int id);
    }
}
