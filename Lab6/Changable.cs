namespace Lab6
{
    public enum ChangeType 
    {
        Created,
        Deleted,
        Moved,
        Updated
    }
    
    public abstract class Changable
    {
        public bool IsChanged;
        public ChangeType LastChange;
    }
}