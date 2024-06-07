#include <stdio.h>
#include <stdlib.h>
// 定义Student结构体
typedef struct {
    int StudentId;
    // 你可以添加更多字段，比如姓名等
} Student;
// 假设教室座位是5行5列
#define ROWS 5
#define COLS 5
// 创建并初始化Student对象
Student createStudent(int id)
{
    Student student;
    student.StudentId = id;
    return student;
}
// 主函数
int main()
{
    // 教室座位二维数组，这里只是模拟，不实际存储Student对象
    int seats[ROWS][COLS] = { 0};

    // 用于存储Student对象和它们的索引
    Student students[ROWS * COLS];
    int indices[ROWS * COLS][2]; // 每个索引是[行, 列]
    int studentCount = 0;

    // 使用for循环遍历座位，并创建Student对象
    for (int i = 0; i < ROWS; i++)
    {
        for (int j = 0; j < COLS; j++)
        {
            int index = i * COLS + j; // 转换为一维索引
            Student student = createStudent(index);
            students[index] = student;
            indices[index][0] = i;
            indices[index][1] = j;
            studentCount++;
        }
    }

    // 遍历并输出每个Student对象的Id
    for (int k = 0; k < studentCount; k++)
    {
        printf("Student at position [%d, %d] has ID: %d\n", indices[k][0], indices[k][1], students[k].StudentId);
    }

    return 0;
}using System;

public class Class1
{
	public Class1()
	{
	}
}
