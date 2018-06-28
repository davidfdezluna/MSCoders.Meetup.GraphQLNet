<template>
  <div>
      <form @submit.prevent
        @submit="search()">

        <div class="ui action input">
            <input v-model="name"
            placeholder="Series name"
            type="text"
            required />

          <button class="ui icon pink button">
            <i class="search icon"></i>
          </button>
      </div>
      </form>
      <br/>
      <div v-if="!!series.length" class="ui special cards">
        <SerieCard v-for="serie in series" :key="serie.id" :serie="serie"></SerieCard>        
      </div>
  </div>
</template>

<script>
import gql from "graphql-tag";
import SerieCard from './SerieCard'

// GraphQL query
const pingQuery = gql`
  {
    nombre
  }
`;
const queries = {
  allSeries: gql`
    {
      allseries {
        id
        name
        overview
        imageUrl
      }
    }
  `,
  series: gql`query getSeries($nameS:String)
    {
      series(name: $nameS) {
        id
        name
        overview
        imageUrl
        firstAired
        actors {
          id name 
          imageUrl
          series {id}
        }
      }
    }
  `
};

export default {
  data: () => ({
    name: "",
    series: []
  }),
  methods: {
    search() {
      this.$emit("updateSearch", this.name);
      var vm = this;
      this.$store.dispatch('SEARCH_SERIES', this.name);
      this.$apollo
        .query({ query: queries.series, variables: { nameS: vm.name } })
        .then(res => {
          vm.series = res.data.series;
        });
    }
  },
  components:{
    SerieCard
  }
};
</script>

<style>
form {
  width: 222px;
  margin: 0 auto;
}
</style>
