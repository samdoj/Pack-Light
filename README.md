# Decompose
Scans your code for unused classes in composer modules.  If your code doesn't directly use an installed class, and doesn't call a method that uses it, this tool removes it.  If your code uses a class that has methods which reference another class, but you don't use those methods, provides the option to remove those methods and associated classes. 
