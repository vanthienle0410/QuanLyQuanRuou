using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangRuou_DAL.Models;
namespace QuanLyCuaHangRuou_BUS
{
    public class QuyenBUS
    {
        private Model1 context = new Model1();

        public void Add(Quyen newQuyen)
        {
            throw new NotImplementedException();
        }

        public void Delete(string originalMaQuyen)
        {
            throw new NotImplementedException();
        }

        public List<Quyen> GetAll()
        {
            return context.Quyens.ToList();
        }

        public Quyen GetById(string ma)
        {
            return context.Quyens.FirstOrDefault(x => x.MaQuyen == ma);
        }

        public void Update(Quyen updatedQuyen)
        {
            throw new NotImplementedException();
        }
    }
}