module.exports = (storybookBaseConfig, configType) => {
  storybookBaseConfig.resolve.extensions.push('.ts', '.tsx', '.vue', '.css', '.less', '.scss', '.sass', '.html')

  storybookBaseConfig.module.rules.push(
    {
      test: /\.ts$/,
      exclude: /node_modules/,
      use: [
        {
          loader: 'ts-loader',
          options: {
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
    },
    {
      test: /\.(woff(2)?|ttf|eot|svg)(\?v=\d+\.\d+\.\d+)?$/,
      use: [
        {
          loader: 'file-loader',
          options: {
            name: '[name].[ext]',
            outputPath: 'fonts/'
          }
        }]
    },
    {
      test: /\.(png|jp(e*)g|svg)$/,
      use: [{
        loader: 'url-loader',
        options: {
          limit: 8000, // Convert images < 8kb to base64 strings
          name: 'images/[hash]-[name].[ext]'
        }
      }]
    }
  )


  return storybookBaseConfig;
};