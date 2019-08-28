using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Models;
namespace Controller.Controllers
{
    public class SegmentController
    {

        public List<Segment> GetSegment()
        {
            try
            {
                using (TeamCellContext _BDContext = new TeamCellContext())
                {
                    var result = _BDContext.Segment.ToList();
                    return result;
                }

            }
            catch (Exception)
            {
                return new List<Segment>();
            }
        }

        public bool AddOrUpdateClient(Segment segment)
        {
            try
            {
                using (TeamCellContext _DBContext = new TeamCellContext())
                {
                    _DBContext.Segment.AddOrUpdate(segment);
                    _DBContext.SaveChanges();
                    return true;
                }

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Segment GetIdSegment(int id)
        {
            try
            {
                using (TeamCellContext _DBContext = new TeamCellContext())
                {
                    return _DBContext.Segment.Where(x => x.IdSegment == id).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                return new Segment();
            }
        }
    }
}
