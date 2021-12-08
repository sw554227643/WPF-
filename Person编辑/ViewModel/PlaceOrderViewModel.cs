using Person编辑.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person编辑.ViewModel
{
    public class PlaceOrderViewModel : BindableBase
    {
        public event Action Done = delegate { };

        public PlaceOrderViewModel()
        {
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave);
        }

        private async void OnSave(object obj)
        {
            Done();
        }

        private bool CanSave(object arg)
        {
            return true;
        }

        private void OnCancel(object obj)
        {
            Done();
        }

        private bool _EditMode;
        public bool EditMode
        {
            get { return _EditMode; }
            set { SetProperty(ref _EditMode, value); }
        }

        private SimpleEditableCustomer _Customer;
        public SimpleEditableCustomer Customer
        {
            get { return _Customer; }
            set { SetProperty(ref _Customer, value); }
        }

        public RelayCommand CancelCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        private Customer _editngCustomer = null;

       public void SetCustomer(Customer cust)
        {
            _editngCustomer = cust;
            Customer = new SimpleEditableCustomer();
            CopyCustomer(cust, Customer);
        }

        private void CopyCustomer(Customer source, SimpleEditableCustomer target)
        {
            target.Id = source.Id;
            if (EditMode)
            {
                target.Id = source.Id;
                target.Name = source.Name;
                target.Phone = source.Phone;
                target.Email = source.Email;
            }
        }
    }
}
