<template>
  <table class="table table-striped table-sm color-icon-label-table text-right">
    <thead>
    <tr>
      <td>Symbol</td>
      <td>Price</td>
      <td>Percent 24H</td>
      <td>Volume 24H</td>
    </tr>
    </thead>
    <tbody v-if="topGainers != null">
    <tr v-for="coin in topGainers">
      <td class="text-left">{{coin.symbol}}</td>
      <td>{{coin.price}}</td>
      <td>{{coin.percentChange24H}}</td>
      <td>{{coin.volume24H}}</td>
    </tr>
    </tbody>
  </table>
</template>

<script>
  import axios from 'axios';

  const latestDataUrl = 'http://localhost:5000/api/v1/TopCrypto/';

  export default {
    name: "CryptoTopGainers",
    data() {
      return {
        topGainers: null
      }
    },
    methods: {
      getTopGainers: function () {
        axios.get(latestDataUrl + 'TopGainers')
          .then((response) => {
              this.topGainers = response.data.data
            },
            (error) => {
              console.log(error)
            })
      }
    },
    created() {
      this.getTopGainers()
    }
  }
</script>

<style scoped>

</style>
