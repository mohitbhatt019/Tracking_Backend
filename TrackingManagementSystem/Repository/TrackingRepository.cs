using Microsoft.AspNetCore.Identity;
using TrackingManagementSystem.Data;
using TrackingManagementSystem.Models;
using TrackingManagementSystem.Repository.IRepository;

namespace TrackingManagementSystem.Repository
{
    public class TrackingRepository : ITrackingRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        public TrackingRepository(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public ApplicationUser? CheckPersonsId(string userId)
        {
            var validatasender = _userManager.FindByIdAsync(userId).Result;
            return validatasender;
        }

        public bool CreateTracking(Tracker tracking)
        {
           var save= _context.trackers.Add(tracking);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteTracking(string senderId, string ReceieverId)
        {
            if (senderId == null && ReceieverId==null) { return false; }
            var findTrack=_context.trackers.Where(sender=>sender.UserId==senderId && sender.DataChangeUserId==ReceieverId).ToList();
            foreach (var track in findTrack)
            {
                _context.trackers.Remove(track);
                _context.SaveChanges(true);
            }
            return true;
        }

        //public ICollection<Tracker> GetAll(string DataChangeUserId)
        //{
        //    var getAll = _context.trackers.Where(u => u.UserId == DataChangeUserId).ToList();
        //    return getAll;
        //}

        public ICollection<Tracker> GetAll(string DataChangeUserId)
        {
            return _context.trackers
                .Where(u => u.UserId == DataChangeUserId)
                .ToList();
        }

        public ICollection<Tracker> GetCompany(string DataChangeUserId)
        {
            var data = _context.trackers.Where(u => u.UserId == DataChangeUserId).ToList();
            return data; ;
        }

        public ICollection<Company> GetSpecificUserData(string UserID)
        {
            var data = _context.companies.Where(u => u.ApplicationUserId == UserID).ToList();
            return data;
        }
    }
}
