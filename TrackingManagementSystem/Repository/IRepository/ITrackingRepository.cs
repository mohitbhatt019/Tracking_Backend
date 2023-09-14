using System.Xml;
using TrackingManagementSystem.Models;

namespace TrackingManagementSystem.Repository.IRepository
{
    public interface ITrackingRepository
    {
        public bool CreateTracking(Tracker tracking);
        ICollection<Tracker> GetCompany(string DataChangeUserId);
        public ApplicationUser? CheckPersonsId(string userId);
        public ICollection<Company> GetSpecificUserData(string UserID);
        public ICollection<Tracker> GetAll(string DataChangeUserId);
        bool DeleteTracking(string senderId, string ReceieverId);


    }
}
