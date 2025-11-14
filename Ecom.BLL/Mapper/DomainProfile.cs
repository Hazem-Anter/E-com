
using Ecom.BLL.ModelVM.Product;

namespace Ecom.BLL.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {

            //ProductImageUrl Mapping
            CreateMap<ProductImageUrl, GetProductImageUrlVM>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product != null ? src.Product.Title : null));

            CreateMap<CreateProductImageUrlVM, ProductImageUrl>()
                .ConstructUsing(vm => new ProductImageUrl(vm.ImageUrl!, vm.ProductId, vm.CreatedBy!));

            CreateMap<UpdateProductImageUrlVM, ProductImageUrl>()
                .ConstructUsing(vm => new ProductImageUrl(vm.ImageUrl!, vm.ProductId, vm.UpdatedBy!))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<ProductImageUrl, DeleteProductImageUrlVM>().ReverseMap();

            //Product Mapping
            // Product mappings
            CreateMap<Product, GetProductVM>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand != null ? src.Brand.Name : null))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : null));

            CreateMap<CreateProductVM, Product>()
                .ConstructUsing(vm => new Product(
                    vm.Title, vm.Description, vm.Price, vm.DiscountPercentage,
                    vm.Stock, vm.ThumbnailUrl ?? "default.png", vm.CreatedBy ?? "system", vm.BrandId, vm.CategoryId
                ));

            CreateMap<Product, UpdateProductVM>().ReverseMap(); // Update uses Update() inside repo

            CreateMap<Product, DeleteProductVM>().ReverseMap();

            //Brand Mappings

            CreateMap<Brand, GetBrandVM>().ReverseMap();

            CreateMap<CreateBrandVM, Brand>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<UpdateBrandVM, Brand>()
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<DeleteBrandVM, Brand>()
                .ForMember(dest => dest.Name, opt => opt.Ignore())
                .ForMember(dest => dest.ImageUrl, opt => opt.Ignore())
                .ReverseMap();
        
        }

    }
}
