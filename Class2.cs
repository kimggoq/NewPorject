using System;
using System.Reflection;
using System.Attributes; // 注意：在C#中，自定义属性通常继承自Attribute类

// 自定义属性
[AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
public class CustomAttribute : Attribute
{
    public string Description { get; set; }

    public CustomAttribute(string description)
    {
        Description = description;
    }
}

// Human基类
public class Human
{
    // 示例属性
    public string Name { get; set; }

    // 示例私有字段
    private int _age;

    // 示例私有方法
    private void SetAge(int age)
    {
        _age = age;
    }
}

// Student类继承自Human类
[CustomAttribute("Student class description")]
public class Student : Human
{
    // 自定义属性
    [CustomAttribute("Student name attribute")]
    public string StudentName { get; private set; }

    // 构造函数
    public Student(string name)
    {
        Name = name;
    }

    // 公开方法
    public void SetName(string name)
    {
        StudentName = name;
    }

    // 私有方法（示例）
    private void SomePrivateMethod()
    {
        // ...
    }
}