# Pack Light

* This will do two things.  It will go through your folder structure to see if there are any packages that you're no longer using.  It will fix the dependency list so that these packages are removed. commenting out the packages.

* This will scan for unused classes in your package folders.  It will delete any classes, constants, variables or functions that are safe to delete, meaning your code never calls them through any part of a call chain.  
