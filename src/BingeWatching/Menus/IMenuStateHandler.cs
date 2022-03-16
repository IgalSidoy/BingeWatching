
using System.Threading.Tasks;
namespace BingeWatching.Menus
{
    public interface IMenuStateHandler
    {
        public bool CanHandle(MenuState menuState);
        public void Handle();
    }
}