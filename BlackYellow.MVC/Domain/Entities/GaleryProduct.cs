namespace BlackYellow.MVC.Domain.Entites
{
    public class GaleryProduct
    {
        public GaleryProduct(string PathImage, string Name , bool isPrincipal)
        {
            this.NameImage = Name;
            this.isPrincipal = isPrincipal;
            this.PathImage = PathImage + Name;
            
        }

        public int GaleryProductId { get; set; }
        public string NameImage{get; set;}
        public string PathImage {get;   set;}
        public bool isPrincipal { get; set; }
        

        

        
    }
}