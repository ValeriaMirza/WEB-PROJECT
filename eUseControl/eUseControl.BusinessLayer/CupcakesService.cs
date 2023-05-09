using System.Collections.Generic;
using System.Linq;
using eUseControl.DomainModels;
using eUseControl.Repositories;
using eUseControl.ViewModels;
using AutoMapper;
using AutoMapper.Configuration;

namespace eUseControl.BusinessLogic
{
    public interface ICupcakesService
    {
        List<CupcakeViewModel> GetCupcakes();
        CupcakeViewModel GetCupcakeById(int id);
        int InsertCartItem(CartItemViewModel item);
        CartItemViewModel GetCartItem(int cartItemId);
         List<CartItemViewModel> GetCartItems();
        void DeleteCartItem(int cartItemId);


    }

    public class CupcakesService : ICupcakesService
    {
        private readonly ICupcakesRepository _cupcakesRepository;

        public CupcakesService()
        {
            _cupcakesRepository = new CupcakesRepository();
        }

        public List<CupcakeViewModel> GetCupcakes()
        {
            var cupcakes = _cupcakesRepository.GetCupcakes();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Cupcake, CupcakeViewModel>());
            IMapper mapper = config.CreateMapper();
            var cupcakesViewModel = mapper.Map<List<Cupcake>, List<CupcakeViewModel>>(cupcakes);
            return cupcakesViewModel;
        }

        public CupcakeViewModel GetCupcakeById(int id)
        {
            var cupcake = _cupcakesRepository.GetCupcakeById(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Cupcake, CupcakeViewModel>());
            IMapper mapper = config.CreateMapper();
            var cupcakeViewModel = mapper.Map<Cupcake, CupcakeViewModel>(cupcake);
            return cupcakeViewModel;
        }

        public int InsertCartItem(CartItemViewModel item)
        {
            // Convert the AddToCartViewModel object to a CartItem object using AutoMapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CartItemViewModel, CartItem>());
            IMapper mapper = config.CreateMapper();
            var cartItem = mapper.Map<CartItemViewModel, CartItem>(item);

            // Insert the CartItem into the database and return its id
            int cartItemId = _cupcakesRepository.InsertCartItem(cartItem);

            return cartItemId;
        }
        public void DeleteCartItem(int cartItemId)
        {
            _cupcakesRepository.DeleteCartItem(cartItemId);
        }

        public CartItemViewModel GetCartItem(int cartItemId)
        {
            // Get the CartItem from the database
            var cartItem = _cupcakesRepository.GetCartItemById(cartItemId);

            // If the CartItem doesn't exist, return null
            if (cartItem == null)
            {
                return null;
            }

            // Convert the CartItem object to a CartItemViewModel object using AutoMapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CartItem, CartItemViewModel>());
            IMapper mapper = config.CreateMapper();
            var cartItemViewModel = mapper.Map<CartItem, CartItemViewModel>(cartItem);

            return cartItemViewModel;
        }

        public List<CartItemViewModel> GetCartItems()
        {
            // Get all CartItems from the database
            var cartItems = _cupcakesRepository.GetCartItems();

            // If there are no CartItems, return an empty list
            if (cartItems == null)
            {
                return new List<CartItemViewModel>();
            }

            // Convert the list of CartItem objects to a list of CartItemViewModel objects using AutoMapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CartItem, CartItemViewModel>());
            IMapper mapper = config.CreateMapper();
            var cartItemViewModels = mapper.Map<List<CartItem>, List<CartItemViewModel>>(cartItems);

            return cartItemViewModels;
        }




    }
}
