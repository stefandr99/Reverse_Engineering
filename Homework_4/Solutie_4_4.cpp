int a, b;
a = 16;
b = 0;

while (a > 0) {
	b++;
	a = a >> 1; // a /= 2;
}

// Calculeaza cel mai mic b astfel incat (2^b) >= a; 
// In acest caz calculeaza (2^b) = 16, deci b = 4;