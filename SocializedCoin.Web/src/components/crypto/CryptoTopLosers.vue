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
    <tbody v-if="topLosers != null">
    <tr v-for="coin in topLosers">
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
    name: "CryptoTopLosers",
    data() {
      return {
        topLosers: null
      }
    },
    methods: {
      getTopLosers: function () {
        axios.get(latestDataUrl + 'TopLosers')
          .then((response) => {
              this.topLosers = response.data.data
            },
            (error) => {
              console.log(error)
            })
      }
    },
    created() {
      this.getTopLosers()
    }
  }
</script>

<style scoped>

</style>
