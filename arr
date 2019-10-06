#include<stdio.h>
void init(int arr[])
{
	for (int i=0; i < 5; i++)
	{
		arr[i] = i+1;
		printf("%d\t", arr[i]);
	}printf("\n");
}
void empty(int arr[])
{
	for (int i = 0; i < 5; i++)
	{
		arr[i] = 0;
		printf("%d\t", arr[i]);
	}
}
void reverse(int arr[])
{
	for (int i = 0; i < 5 / 2; i++)
	{
		int tmp = arr[i];
		arr[i] = arr[4 - i];
		arr[4 - i] = tmp;
	}
	for (int i = 0; i < 5; i++)
	{
		printf("%d\t", arr[i]);
	}
	printf("\n");
}
int main()
{
	int input = 0;
	int arr[5];
	init(arr);
	reverse(arr);
	empty(arr);
	return 0;
}
