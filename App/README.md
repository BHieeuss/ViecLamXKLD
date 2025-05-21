<!-- Build dist -->
ng run App:build:production --base-href "/ViecLamXKLD/"

<!-- Deploy GitHub -->
npx angular-cli-ghpages --dir=dist/app/browser --repo=https://github.com/BHieeuss/ViecLamXKLD.git 