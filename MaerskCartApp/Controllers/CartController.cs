using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaerskCartApp.Business;
using MaerskCartApp.BusinessEntities;
using MaerskCartApp.CartModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaerskCartApp.Controllers
{
    //[Route("[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {

        private readonly ICartProcessor cartProcessor;

        private List<CartItems> Cartlist;
        public CartController(ICartProcessor cartProcessor)
        {
            this.cartProcessor = cartProcessor;
        }
        [HttpGet]
        [Route("GetCartList")]
        public List<CartItems> GetCartList()
        {
           if(Cartlist == null)
            {
                GetFakeData();
                //Cartlist = this.Cartlist;
            }

            //Explicit class Invocation instead Dependency Resolver
            cartProcessor.ProcessCartdata(Cartlist);


            return Cartlist;
        }

        [HttpPost]
        [Route("GetCartList")]
        public List<CartItems> GetCartList([FromBody] List<CartItems> cartitems)
        {
            if (Cartlist == null)
            {
                GetFakeData();
            }

            cartProcessor.ProcessCartdata(Cartlist);

            return Cartlist;
        }


        [Route("GetData")]
        public void GetFakeData()
        {
            Cartlist = new List<CartItems>()
                {
                    new CartItems
                    {
                        ItemName = "A",
                        ItemCost = 50,
                        ItemSkuNumbers=4
                    },

                    new CartItems
                    {
                        ItemName = "B",
                        ItemCost = 30,
                        ItemSkuNumbers=3
                    },

                    new CartItems
                    {
                        ItemName = "C",
                        ItemCost = 20,
                        ItemSkuNumbers=2
                    },
                    new CartItems
                    {
                        ItemName = "D",
                        ItemCost = 15,
                        ItemSkuNumbers=1
                    }
                };
        }
    }
}
