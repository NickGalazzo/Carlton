namespace Carlton.Dashboard.ViewModels.ApartmentStatus
{
    public class ApartmentStatusListItemViewModel
    {
        public string StatusName { get; set; }
        public ApartmentStatuses StatusValue { get; set; }
        public string StatusIcon { get; set; }

        public ApartmentStatusListItemViewModel(string statusName, ApartmentStatuses statusValue, string statusIcon)
        {
            StatusName = statusName;
            StatusValue = statusValue;
            StatusIcon = statusIcon;
        }
    }

    public class ApartmentGarbageStatusListItemViewModel : ApartmentStatusListItemViewModel
    {
        public ApartmentGarbageStatusListItemViewModel(ApartmentStatuses statusValue)
            :base("Garbage", statusValue, "mdi-delete")
        { }
    }

    public class ApartmentRecycleStatusListItemViewModel : ApartmentStatusListItemViewModel
    {
        public ApartmentRecycleStatusListItemViewModel(ApartmentStatuses statusValue)
            : base("Recycle", statusValue, "mdi-recycle")
        { }
    }

    public class ApartmentShoppingStatusListItemViewModel : ApartmentStatusListItemViewModel
    {
        public ApartmentShoppingStatusListItemViewModel(ApartmentStatuses statusValue)
            : base("Shopping", statusValue, "mdi-cart")
        { }
    }

    public class ApartmentCleaningStatusListItemViewModel : ApartmentStatusListItemViewModel
    {
        public ApartmentCleaningStatusListItemViewModel(ApartmentStatuses statusValue)
            : base("Cleaning", statusValue, "mdi-spray-bottle")
        { }
    }

    public class ApartmentLaundryStatusListItemViewModel : ApartmentStatusListItemViewModel
    {
        public ApartmentLaundryStatusListItemViewModel(ApartmentStatuses statusValue)
            : base("Laundry", statusValue, "mdi-washing-machine")
        { }
    }

    public class ApartmentDryCleaningStatusListItemViewModel : ApartmentStatusListItemViewModel
    {
        public ApartmentDryCleaningStatusListItemViewModel(ApartmentStatuses statusValue)
            : base("Dry Cleaning", statusValue, "mdi-tie")
        { }
    }
}
