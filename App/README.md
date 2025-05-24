<!-- Build dist for github -->

ng run App:build:production --base-href "/ViecLamXKLD/"

<!-- Build dist for domain -->

ng run App:build:production --base-href "/"

<!-- Deploy GitHub -->

npx angular-cli-ghpages --dir=dist/app/browser --repo=https://github.com/BHieeuss/ViecLamXKLD.git
