
namespace Jondu.Skandia.Simulators.UI.MVP
{
    public class BasePresenter<V> where V : IView
    {
        protected V _View;

        public BasePresenter(V view)
        {
            _View = view;
        }
    }
}
