module.exports = {
    entry: "./js/index.js",
    output: {
        filename: "./dist/bundle.js"
    },
    devtool: "source-map",
    resolve: {
        extensions: ["", ".webpack.js", ".web.js", ".ts", ".tsx", ".js"]
    },
    module: {
        preLoader: [{ test: /\.js$/, loader: "source-map-loader" }]
    },
};