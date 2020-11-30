namespace PortalGames.ViewModels
{
    public class SortViewModel
    {
        public SortState NameSort { get; private set; } 
        public SortState PriceSort { get; private set; }   
        public SortState DateSort { get; private set; }  
        public SortState Current { get; private set; }  

        public SortViewModel(SortState sortOrder)
        {
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            PriceSort = sortOrder == SortState.PriceAsc ? SortState.PriceDesc : SortState.PriceAsc;
            DateSort = sortOrder == SortState.DateAsc ? SortState.DateDesc : SortState.DateAsc;
            Current = sortOrder;
        }
    }
    public enum SortState
    {
        NameAsc,   
        NameDesc,
        PriceAsc, 
        PriceDesc,    
        DateAsc, 
        DateDesc 
    }
}