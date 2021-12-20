using System;

namespace Lab6
{
    public abstract class Entity : Changable
    {
        public string Title => _title;
        
        private static int ID = 0;

        protected int _id;
        private string _title;
        protected Entity _parent;
        protected bool _isDeleted;

        protected Entity(string title, Entity parent)
        {
            _title     = title;
            _id        = ++ID;
            IsChanged  = true;
            LastChange = ChangeType.Created;
            _parent    = parent;
        }
        public virtual void TryNameChange()
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
                    Console.WriteLine($"The {Title} was updated");
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