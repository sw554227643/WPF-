using Person编辑.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person编辑.ViewModel
{
    public class MainWindowViewModel: BindableBase
    {

        private CustomerListViewModel _customerListViewModel = new CustomerListViewModel();
        private OrderViewModel _orderViewModel = new OrderViewModel();
        private PlaceOrderViewModel _placeOrderViewModel = new PlaceOrderViewModel();
        public MainWindowViewModel()
        {
            CurrentCommand = new RelayCommand(Current);
            _customerListViewModel.PlaceOrderRequested += NavToOrder;
            _customerListViewModel.NavgateEditOrder += NavToEdit;
        }

        private void NavToEdit(Customer obj)
        {
            CurrentViewModel = _placeOrderViewModel;
        }

        private void NavToOrder(Guid customerId)
        {
            _orderViewModel.CustomerId = customerId;
            CurrentViewModel = _orderViewModel;
        }

        private void Current(object obj)
        {
            switch (obj)
            {
                case "us1":
                    CurrentViewModel = _customerListViewModel;
                    break;
                case "us2":
                    CurrentViewModel = _orderViewModel;
                    break;
                default:
                    break;
            }
        }

        private BindableBase _currentViewModel;
        public BindableBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        public RelayCommand CurrentCommand { get; set; }

    }
}
