using Person编辑.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person编辑.ViewModel
{
    public class CustomerListViewModel: BindableBase
    {
        public CustomerListViewModel()
        {
            PlaceOrderCommand = new RelayCommand<Customer>(OnPlaceOrder);
            EditOrderCommand = new RelayCommand<Customer>(OnEditCustomer);
            Customers = new ObservableCollection<Customer>();
        }

        private void OnEditCustomer(Customer customer)
        {
            NavgateEditOrder(customer);
        }
        public event Action<Customer> NavgateEditOrder = delegate { };
        public event Action<Guid> PlaceOrderRequested = delegate { };
        private void OnPlaceOrder(Customer obj)
        {
            PlaceOrderRequested(obj.Id);
        }

        public void LoadCustomer()
        {
            for (int i = 0; i < 5; i++)
            {
                Customers.Add(new Customer() { Name = "name" + i });
            }
        }

        private ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set { SetProperty(ref _customers, value); }
        }

        public RelayCommand<Customer> PlaceOrderCommand { get; set; }
        public RelayCommand<Customer> EditOrderCommand { get; set; }
    }
}
