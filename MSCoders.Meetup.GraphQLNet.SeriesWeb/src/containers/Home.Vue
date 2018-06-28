<template>

    <div class="page">
        <h1>Search: {{ textSearch | capitalize }}</h1>
        <SearchForm @updateSearch="updateSearch"></SearchForm>
    </div>

</template>

<script>

import SearchForm from '../components/Search'

export default {
    data(){
        return {
            textSearch: ''
        }
    },
    components:{
        SearchForm
    },
    methods:{
        updateSearch(text){
            this.textSearch = text
        }
    },
    filters: {
      capitalize: function (value) {
        if (!value) return ''
        value = value.toString()
        return value.charAt(0).toUpperCase() + value.slice(1)
      }
    }
};
</script>

<style>

</style>
