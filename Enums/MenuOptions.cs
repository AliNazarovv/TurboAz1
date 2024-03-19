using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboAzORM.Enums
{
    public enum MenuOption : byte
    {
        //Brand
        AddBrand = 1,
        DeleteBrand, // Not finished
        EditBrand,
        GetAllBrands,

        //Model
        AddModel,
        DeleteModel,// Not finished
        EditModel,
        GetAllModels,
        GetModelById,

        // Announcement
        AddAnnouncement,
        DeleteAnnouncement,// Not finished
        EditAnnouncement,// Not finished
        GetAllAnnouncements,
        GetAnnouncementById,
    }
}
