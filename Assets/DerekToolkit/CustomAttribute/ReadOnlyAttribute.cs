using UnityEngine;

namespace DerekToolkit.CustomAttribute
{
    /// <summary>
    /// 设置变量是否只读。
    /// 使用范围：变量、有Serializable属性的类或结构体。
    /// 如果需要可改写则需填写ReadOnly(false)
    /// </summary>
    public class ReadOnlyAttribute : PropertyAttribute
    {
        public bool isReadonly { get; private set; }
    
        public ReadOnlyAttribute(bool _isReadonly = true)
        {
            isReadonly = _isReadonly;
        }
    }    
}

