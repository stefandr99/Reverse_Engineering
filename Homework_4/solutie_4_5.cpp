int a, b, c, d;
a = b = 53;
c = d = 0;

while(b > 0) {
	c = (c * 10) + (b % 10);
	b = b / 10;
}

if (a == c)
	d = 1;
else 
	d = 2;

// verifica daca un numar este palindrom