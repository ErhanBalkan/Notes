# Selection Sort

[22,27,16,2,18,6] -> Selection Sort
1. [2,27,16,22,18,6] => (n-1)
2. [2,6,16,22,18,27] => (n-2)
3. [2,6,16,18,22,27] => (n-3)

```
1. işlemde n tane işlem yapıldı `=> 6 (6 adet sayı olduğu için)`
2. işlemde n-1 tane işlem yapıldı. `=> 6-1 = 5`
3. işlemde n-2 tane işlem yapıldı. `=> 6-2 = 4`
4. işlemde n-3 tane işlem yapıldı 2. işlem yapıldığında 16 zaten otomatik sıraya gelmiş oldu 
27 zaten sondaydı 18 ile 22'nin değişmesi yeterli oldu. `=> 6-3 = 3`
```

# Big o Notation

`O(n^2)` 

# Time Complexity

##### Dizi sıralandıktan sonra 18 sayısı aşağıdaki case'lerden hangisinin kapsamına girer?

1. Average case: Aradığımız sayının ortada olması
2. Worst case: Aradığımız sayının sonda olması
3. Best case: Aradığımız sayının dizinin en başında olması

`Bu durumda dizi sıralandığında 18 sayısı dizinin tam ortasında olur bu da Avarage case kapsamına girer.`

# Selection Sort
[7,3,5,8,2,9,4,15,6] dizisinin Selection Sort'a göre ilk 4 adımını yazınız.

```
1- [2,3,5,8,7,9,4,15,6]
2- [2,3,4,8,7,9,5,15,6]
3- [2,3,4,5,7,9,8,15,6]
4- [2,3,4,5,6,9,8,15,7]
```

