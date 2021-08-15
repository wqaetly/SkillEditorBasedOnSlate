# SkillEditorBasedOnSlate
基于ParadoxNotion Slate的帧同步技能编辑器，博客链接：[ParadoxNotion-Slate学习笔记与拓展计划](https://www.lfzxb.top/unity-slate-study-and-extendplan/)

项目使用了两款插件，请自行购买并导入Assets/Plugins/目录中

 - [ParadoxNotion-Slate](https://slate.paradoxnotion.com/)
 - [Odin](https://odininspector.com/)

## 功能列表

- [x] 基于帧同步的技能系统运行时
- [ ] 技能数据的编辑与导出
- [ ] 测试用例

## 更改内容

由于我们需要用Odin在Inpsector绘制内容，所以需要更改Slate自带的CustomEditor绘制

```csharp
public class ActionClipInspector : OdinEditor
```

由于我们为了分离数据运行时逻辑，采用了较为复杂的引用和层级关系，所以需要借助Odin的序列化，也就需要更改Slate ActionClip的继承对象为SerializedMonoBehaviour

```csharp
abstract public class ActionClip : SerializedMonoBehaviour, IDirectable, IKeyable
```

