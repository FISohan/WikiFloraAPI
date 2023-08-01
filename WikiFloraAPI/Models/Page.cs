namespace WikiFloraAPI.Models
{
    public class Page<T>
    {
        public int MaxPageIndex { get; set; }
        public int currentPageIndex { get; set; }
        public  List<T>? Data { get; set;}
    }
}
