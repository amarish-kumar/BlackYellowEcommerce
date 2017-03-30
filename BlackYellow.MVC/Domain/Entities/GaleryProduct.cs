namespace BlackYellow.MVC.Domain.Entites
{
    public class GaleryProduct
    {
        public GaleryProduct()
        {

        }
        public GaleryProduct(string Path, string Name , bool isPrincipal)
        {
            this.NameImage = Name;
            this.IsPrincipal = isPrincipal;
            this.PathImage = Path + Name;
            
        }

        public long GaleryProductId { get; set; }
        public string NameImage{get; set;}
        public string PathImage {get;   set;}
        public bool IsPrincipal { get; set; }
        public long ProductId { get; set; }

        public Product Product { get; set; }





    }
}