using AutoMapper;
using MassTransit;
using MediatR;
using Moq;
using ProductService.API.Controllers;
using ProductService.Application.Features.Orders.Queries;

namespace UnitTtest
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {


        }

        [Test]
        public async Task GetAllProductsAsync_ShouldReturnAllProducts()
        {

            var _mediator = new Mock<IMediator>();
            var _publishEndpoint = new Mock<IPublishEndpoint>();
            var _mapper = new Mock<IMapper>();
            var testProducts = GetTestProducts();
            var controller = new ProductController(_mediator.Object, _publishEndpoint.Object, _mapper.Object);
            var result = (await controller.GetProducts()) as List<ProductsVm>;
            Assert.That(result?.Count, Is.EqualTo(testProducts.Count));
        }

        [Test]
        public void GetProduct_ShouldReturnCorrectProduct()
        {

            var _mediator = new Mock<IMediator>();
            var _publishEndpoint = new Mock<IPublishEndpoint>();
            var _mapper = new Mock<IMapper>();
            var testProducts = GetTestProducts();
            var controller = new ProductController(_mediator.Object, _publishEndpoint.Object, _mapper.Object);

            var result = controller.GetProductsByName("IPhone X") as IEnumerable<ProductsVm>;
            Assert.IsNotNull(result);
            Assert.That(result.FirstOrDefault()?.Name, Is.EqualTo(testProducts[1].Name));
        }

        [Test]
        public async Task GetProductAsync_ShouldReturnCorrectProduct()
        {

            var _mediator = new Mock<IMediator>();
            var _publishEndpoint = new Mock<IPublishEndpoint>();
            var _mapper = new Mock<IMapper>();
            var testProducts = GetTestProducts();
            var controller = new ProductController(_mediator.Object, _publishEndpoint.Object, _mapper.Object);

            var result = (await controller.GetProducts()).FirstOrDefault();
            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo(testProducts[1].Name));
        }

        private List<ProductService.Domain.Entities.Product> GetTestProducts()
        {
            return new List<ProductService.Domain.Entities.Product>()
            {
                new ProductService.Domain.Entities.Product()
                {
                            Name = "IPhone X",
                    Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-1.png",
                    Price = 950.00M,
                    Category = "Smart Phone",
                    CreatedDate =  DateTime.UtcNow,
                    LastModifiedDate = DateTime.UtcNow,
                },
                new ProductService.Domain.Entities.Product()
                {
                               Name = "Samsung 10",
                    Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-2.png",
                    Price = 840.00M,
                    Category = "Smart Phone",
                    CreatedDate =  DateTime.UtcNow,
                    LastModifiedDate = DateTime.UtcNow,

                },
                new ProductService.Domain.Entities.Product()
                {
                                 Name = "Huawei Plus",
                    Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-3.png",
                    Price = 650.00M,
                    Category = "White Appliances",
                    CreatedDate =  DateTime.UtcNow,
                    LastModifiedDate = DateTime.UtcNow,

                },
                new ProductService.Domain.Entities.Product()
                {
                                Name = "Xiaomi Mi 9",
                    Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-4.png",
                    Price = 470.00M,
                    Category = "White Appliances",
                    CreatedDate =  DateTime.UtcNow,
                    LastModifiedDate = DateTime.UtcNow,

                },
                new ProductService.Domain.Entities.Product()
                {
                                      Name = "HTC U11+ Plus",
                    Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-5.png",
                    Price = 380.00M,
                    Category = "Smart Phone",
                    CreatedDate =  DateTime.UtcNow,
                    LastModifiedDate = DateTime.UtcNow,

                },
                new ProductService.Domain.Entities.Product()
                {
                                   Name = "LG G7 ThinQ",
                    Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-6.png",
                    Price = 240.00M,
                    Category = "Home Kitchen",
                    CreatedDate =  DateTime.UtcNow,
                    LastModifiedDate = DateTime.UtcNow
                }
            };
        }
    }
}