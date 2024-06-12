namespace Northwind.ToggleRouter;

public static class ListExtensions
{
    public static bool DoesNotContain<T>(this List<T> list, T element)
    {
        return !list.Contains(element);
    }
}