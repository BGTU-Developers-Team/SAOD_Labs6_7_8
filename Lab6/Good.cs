using System;

namespace Lab6
{
    public class Good : Entity
    {
        private float _price;
        private int _amount;

        public Good(string title, int amount, Entity parent, float price) : base(title, parent)
        {
            _price  = price;
            _amount = amount;
        }

        public void SetPrice(int price)
        {
            _price     = price;
            IsChanged = true;
            LastChange = ChangeType.Updated;
        }
        
        public void SetAmount(int amount)
        {
            _amount = amount;
            IsChanged  = true;
            LastChange = ChangeType.Updated;
        }

        public override void TryNameChange()
        {
            if (!IsChanged) return;

            switch (LastChange)
            {
                case ChangeType.Created:
                {
                    Console.WriteLine($"The {Title} was created");
                    break;
                }
                case ChangeType.Deleted:
                {
                    Console.WriteLine($"The {Title} was deleted");
                    break;
                }
                case ChangeType.Updated:
                {
                    Console.WriteLine($"The {Title} was updated and costs now {_price}, amount is {_amount}");
                    break;
                }
                case ChangeType.Moved:
                {
                    Console.WriteLine($"The {Title} was moved to {nameof(_parent)} {_parent.Title}");
                    break;
                }
            }
        }
    }
}