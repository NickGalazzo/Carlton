const ForkTsCheckerWebpackPlugin = require('fork-ts-checker-webpack-plugin');

//const genDefaultConfig = require('@storybook/vue/dist/server/config/defaults/webpack.config.js');

module.exports = (storybookBaseConfig, configType) => {
  //const config = genDefaultConfig(storybookBaseConfig, configType);

  storybookBaseConfig.resolve.extensions.push('.ts', '.tsx', '.vue', '.css', '.less', '.scss', '.sass', '.html')

  storybookBaseConfig.module.rules.push({
    test: /\.ts$/,
    exclude: /node_modules/,
    use: [
      {
        loader: 'ts-loader',
        options: {
          appendTsSuffixTo: [/\.vue$/],
          transpileOnly: true // used with ForkTsCheckerWebpackPlugin
        },
      }
    ],
  }, 
   {
    test: /\.css$/,
    loaders: ["style-loader", "css-loader"]
  },
  {
    test: /\.scss$/,
    loaders: ["style-loader", "css-loader", "sass-loader"]
  })

  storybookBaseConfig.plugins.push(new ForkTsCheckerWebpackPlugin())

  return storybookBaseConfig;
};