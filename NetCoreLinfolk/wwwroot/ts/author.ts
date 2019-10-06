class Author {
    public visits: number = 0;

    public showName(name: string): boolean {
        alert(name);
        return true;
    }

}

let author = new Author();
author.visits = 10;
