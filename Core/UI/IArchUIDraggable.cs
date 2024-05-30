using Terraria.UI;

namespace ArchinzelloUI.Core.UI
{
    public interface IArchUIDraggable {
		abstract void DragStart(UIMouseEvent evt);

		abstract void DragEnd(UIMouseEvent evt);
	}
}