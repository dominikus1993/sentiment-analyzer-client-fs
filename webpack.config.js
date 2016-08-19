const path = require("path");
const webpack = require("webpack");

module.exports = {
    entry: "./js/client.js",
    output: {
        path: path.join(__dirname, "public"),
        filename: "bundle.js"
    },
    devtool: "source-map",
    resolve: {
        extensions: ["", ".webpack.js", ".web.js", ".ts", ".tsx", ".js"]
    },
    module: {
        preLoaders: [{
            test: /\.js$/,
            exclude: /node_modules/,
            loader: "source-map-loader"
        }]
    },
};