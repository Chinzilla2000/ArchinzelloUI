using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;

namespace ArchinzelloUI.Core.UI;

public class ArchUIElement : UIElement {
    public bool IsActive = true;
    
    public override sealed void Draw(SpriteBatch spriteBatch)
    {
        if (!IsActive) return;
        ArchDraw(spriteBatch);
    }
    
    public virtual void ArchDraw(SpriteBatch spriteBatch) => base.Draw(spriteBatch);

    protected override sealed void DrawSelf(SpriteBatch spriteBatch) {
        if (!IsActive) return;
        ArchDrawSelf(spriteBatch);
    }

    protected virtual void ArchDrawSelf(SpriteBatch spriteBatch) => base.DrawSelf(spriteBatch);

    public override sealed List<SnapPoint> GetSnapPoints()
    {
        if (!IsActive) return [];
        return ArchGetSnapPoints();
    }

    public virtual List<SnapPoint> ArchGetSnapPoints() => base.GetSnapPoints();

    public override sealed void LeftClick(UIMouseEvent evt)
    {
        if (!IsActive) return;
        ArchLeftClick(evt);
    }

    public virtual void ArchLeftClick(UIMouseEvent evt) => base.LeftClick(evt);

    public override sealed void LeftDoubleClick(UIMouseEvent evt)
    {
        if (!IsActive) return;
        ArchLeftDoubleClick(evt);
    }

    public virtual void ArchLeftDoubleClick(UIMouseEvent evt) => base.LeftDoubleClick(evt);

    public override sealed void LeftMouseDown(UIMouseEvent evt)
    {
        if (!IsActive) return;
        ArchLeftMouseDown(evt);
    }

    public virtual void ArchLeftMouseDown(UIMouseEvent evt) => base.LeftMouseDown(evt);

    public override sealed void LeftMouseUp(UIMouseEvent evt)
    {
        if (!IsActive) return;
        ArchLeftMouseUp(evt);
    }

    public virtual void ArchLeftMouseUp(UIMouseEvent evt) => base.LeftMouseUp(evt);

    public override sealed void MiddleClick(UIMouseEvent evt)
    {
        if (!IsActive) return;
        ArchMiddleClick(evt);
    }

    public virtual void ArchMiddleClick(UIMouseEvent evt) => base.MiddleClick(evt);

    public override sealed void MiddleDoubleClick(UIMouseEvent evt)
    {
        if (!IsActive) return;
        ArchMiddleDoubleClick(evt);
    }

    public virtual void ArchMiddleDoubleClick(UIMouseEvent evt) => base.MiddleDoubleClick(evt);

    public override sealed void MiddleMouseDown(UIMouseEvent evt)
    {
        if (!IsActive) return;
        ArchMiddleMouseDown(evt);
    }

    public virtual void ArchMiddleMouseDown(UIMouseEvent evt) => base.MiddleMouseDown(evt);

    public override sealed void MiddleMouseUp(UIMouseEvent evt)
    {
        if (!IsActive) return;
        ArchMiddleMouseUp(evt);
    }

    public virtual void ArchMiddleMouseUp(UIMouseEvent evt) => base.MiddleMouseUp(evt);

    public override sealed void MouseOut(UIMouseEvent evt)
    {
        if (!IsActive) return;
        ArchMouseOut(evt);
    }

    public virtual void ArchMouseOut(UIMouseEvent evt) => base.MouseOut(evt);

    public override sealed void MouseOver(UIMouseEvent evt)
    {
        if (!IsActive) return;
        ArchMouseOver(evt);
    }

    public virtual void ArchMouseOver(UIMouseEvent evt) => base.MouseOver(evt);

    public override sealed void RightClick(UIMouseEvent evt)
    {
        if (!IsActive) return;
        ArchRightClick(evt);
    }

    public virtual void ArchRightClick(UIMouseEvent evt) => base.RightClick(evt);

    public override sealed void RightDoubleClick(UIMouseEvent evt)
    {
        if (!IsActive) return;
        ArchRightDoubleClick(evt);
    }

    public virtual void ArchRightDoubleClick(UIMouseEvent evt) => base.RightDoubleClick(evt);

    public override sealed void RightMouseDown(UIMouseEvent evt)
    {
        if (!IsActive) return;
        ArchRightMouseDown(evt);
    }

    public virtual void ArchRightMouseDown(UIMouseEvent evt) => base.RightMouseDown(evt);

    public override sealed void RightMouseUp(UIMouseEvent evt)
    {
        if (!IsActive) return;
        ArchRightMouseUp(evt);
    }

    public virtual void ArchRightMouseUp(UIMouseEvent evt) => base.RightMouseUp(evt);

    public override sealed void ScrollWheel(UIScrollWheelEvent evt)
    {
        if (!IsActive) return;
        ArchScrollWheel(evt);
    }

    public virtual void ArchScrollWheel(UIScrollWheelEvent evt) => base.ScrollWheel(evt);

    public override sealed void XButton1Click(UIMouseEvent evt)
    {
        if (!IsActive) return;
        ArchXButton1Click(evt);
    }

    public virtual void ArchXButton1Click(UIMouseEvent evt) => base.XButton1Click(evt);

    public override sealed void XButton1DoubleClick(UIMouseEvent evt)
    {
        if (!IsActive) return;
        ArchXButton1DoubleClick(evt);
    }

    public virtual void ArchXButton1DoubleClick(UIMouseEvent evt) => base.XButton1DoubleClick(evt);

    public override sealed void XButton1MouseDown(UIMouseEvent evt)
    {
        if (!IsActive) return;
        ArchXButton1MouseDown(evt);
    }

    public virtual void ArchXButton1MouseDown(UIMouseEvent evt) => base.XButton1MouseDown(evt);

    public override sealed void XButton1MouseUp(UIMouseEvent evt)
    {
        if (!IsActive) return;
        ArchXButton1MouseUp(evt);
    }

    public virtual void ArchXButton1MouseUp(UIMouseEvent evt) => base.XButton1MouseUp(evt);

    public override sealed void XButton2Click(UIMouseEvent evt)
    {
        if (!IsActive) return;
        base.XButton2Click(evt);
    }

    public virtual void ArchXButton2Click(UIMouseEvent evt) => base.XButton2Click(evt);

    public override sealed void XButton2DoubleClick(UIMouseEvent evt)
    {
        if (!IsActive) return;
        ArchXButton2DoubleClick(evt);
    }

    public virtual void ArchXButton2DoubleClick(UIMouseEvent evt) => base.XButton2DoubleClick(evt);

    public override sealed void XButton2MouseDown(UIMouseEvent evt)
    {
        if (!IsActive) return;
        ArchXButton2MouseDown(evt);
    }

    public virtual void ArchXButton2MouseDown(UIMouseEvent evt) => base.XButton2MouseDown(evt);

    public override sealed void XButton2MouseUp(UIMouseEvent evt)
    {
        if (!IsActive) return;
        ArchXButton2MouseUp(evt);
    }

    public virtual void ArchXButton2MouseUp(UIMouseEvent evt) => base.XButton2MouseUp(evt);

    public override sealed void ExecuteRecursively(UIElementAction action)
    {
        if (!IsActive) return;
        ArchExecuteRecursively(action);
    }

    public virtual void ArchExecuteRecursively(UIElementAction action) => base.ExecuteRecursively(action);

    public override sealed Rectangle GetViewCullingArea()
    {
        return ArchGetViewCullingArea();
    }

    public virtual Rectangle ArchGetViewCullingArea() => base.GetViewCullingArea();

    public override sealed void Update(GameTime gameTime)
    {
        if (!IsActive) return;
        ArchUpdate(gameTime);  
    }

    public virtual void ArchUpdate(GameTime gameTime) => base.Update(gameTime);
}