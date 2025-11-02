using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangRuou_DAL.Models;

namespace QuanLyCuaHangRuou_BUS
{
    public class DoUongBUS
    {
        private Model1 context = new Model1();

        public List<DoUong> GetAll()
        {
            return context.DoUongs.ToList();
        }

        public DoUong GetById(string ma)
        {
            return context.DoUongs.FirstOrDefault(x => x.MaDo_Uong == ma);
        }

        public void Add(DoUong du)
        {
            context.DoUongs.Add(du);
            context.SaveChanges();
        }

        public void Update(DoUong du)
        {
            var existing = context.DoUongs.FirstOrDefault(x => x.MaDo_Uong == du.MaDo_Uong);
            if (existing != null)
            {
                existing.TenDo_Uong = du.TenDo_Uong;
                existing.DonGia = du.DonGia;
                existing.SoLuongTon = du.SoLuongTon;
                existing.GhiChu = du.GhiChu;
                context.SaveChanges();
            }
        }

        public void Delete(string ma)
        {
            var du = context.DoUongs.FirstOrDefault(x => x.MaDo_Uong == ma);
            if (du != null)
            {
                context.DoUongs.Remove(du);
                context.SaveChanges();
            }
        }
        public DoUong FindByKeyword(string keyword)
        {
            keyword = keyword.ToLower();
            return context.DoUongs
                .FirstOrDefault(x => x.MaDo_Uong.ToLower().Contains(keyword)
                                  || x.TenDo_Uong.ToLower().Contains(keyword));
        }
    }
}